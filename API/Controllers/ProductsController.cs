using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{   //makes sure that the route is a string


    //inject store context into ProductsController 
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;

        private readonly IMapper _mapper;
        // when a request comes in it hits our ProductsController

        public ProductsController(IGenericRepository<Product> productsRepo,
         IGenericRepository<ProductBrand> productBrandRepo,
          IGenericRepository<ProductType> productTypeRepo,
          IMapper mapper
          )
        {
            _mapper = mapper;
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
            _productsRepo = productsRepo;
        }
        //what we are returning
        [HttpGet]
        //action result that returns an http response
        // 200 request
        //synchranous request
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts(string sort)
        {
            //ToList is gonna execute a select query on our database and put em in products
            /*
            However the query could take long so we would like to do
            things in the meantime...

            So you can use your buddy javascript to make it asyncronous
            */

            var spec = new ProductsWithTypesAndBrandsSpecification(sort);

            var products = await _productsRepo.ListAsync(spec);

            //strange syntax...
            return Ok(_mapper.
            Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }
        //interpolation
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        // modify the swagger endpoint return json type {statusCode:0, message:'string"}
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);
            //for swagger if a product is null
            if (product == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Product, ProductToReturnDto>(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetTypesTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }
    }
}