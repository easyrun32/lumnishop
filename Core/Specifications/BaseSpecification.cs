using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    /*
    we wrote this class to replace these two lines in ProductREpository.cs in infrastructure folder

     public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {  
            return await _context.Products
            .Include(p => p.ProductType) // THIS
            .Include(p => p.ProductBrand) // THIS
            .ToListAsync();
        }

    we solved this in the method
    protected void AddInclude 
    */

    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            //we want to get a product with a specific id
            Criteria = criteria;

        }

        public Expression<Func<T, bool>> Criteria { get; }
        // this will have a listn of include statements we can pass
        public List<Expression<Func<T, object>>> Includes { get; } =
            new List<Expression<Func<T, object>>>();
        //we can access the method within the class
        // is why we use protected
        // Any child classes as well
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }


    }
}