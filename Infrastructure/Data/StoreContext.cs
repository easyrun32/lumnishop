
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{

    //Derive from a class
    //
    public class StoreContext : DbContext
    {
        //we need to give it some options so give it a constructure?
        //@params connectionstring, base contructure<- within the library dbContext
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }
        //Allws us to query through our entities with get set;
        //generate a table called products
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }

        public DbSet<ProductType> productTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}