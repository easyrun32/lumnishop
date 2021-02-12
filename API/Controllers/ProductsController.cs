using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    //inject store context into ProductsController 
    // SOOOO WE NEED A CONSTructerrr
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        //So when a request comes in it hits our ProductsController

        public ProductsController(StoreContext context)
        {
            _context = context;
        }
        //what we are returning
        [HttpGet]
        //action result that returns an http response
        // 200 request
        //synchranous request
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            //ToList is gonna execute a select query on our database and put em in products
            /*
            However the query could take long so we would like to do
            things in the meantime...

            So you can use your buddy javascript to make it asyncronous
            */
            var products = await _context.Products.ToListAsync();


            return Ok(products);
        }
        //interpolation
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}