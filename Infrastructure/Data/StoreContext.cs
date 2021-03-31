
using System.Linq;
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

        public DbSet<ProductType> ProductTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType
                                     .GetProperties()
                                     .Where(p => p.PropertyType == typeof(decimal));
                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name)
                                    .Property(property.Name)
                                    .HasConversion<double>();
                    }
                }
            }
        }
    }
}