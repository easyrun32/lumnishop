using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
//We want this injectedable so we ......
// go to the startup and make it as a service!
namespace Infrastructure.Data
{
    //From CORE/INTERFACE
    /*
    include prevent null values within our data
    However we want to include generics to write less code 
    when it becomes huge.
    we use T but there is a problem and that we have no access to puting in T for
    generics.

    So we use the specification pattern to solve this
    */
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        //CONSTRUCTURE
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
             .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .FirstOrDefaultAsync(p => p.Id == id);

        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {   //quering the product list and adding product type and brand based
            // on the numnbers 
            return await _context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductsBrandsAsync()
        {
            //include stuff within the product.json
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductsTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}