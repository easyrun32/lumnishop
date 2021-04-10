using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        // static is used to not generate an instance of
        // the SpecificationEvalutor class
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
         ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if (spec.Criteria != null)
            {

                query = query.Where(spec.Criteria); // p => p.ProductTypeId == id
            }
            /*
            it's doing this 
             return await _context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            
            ProductRepository.cs
            */

            if (spec.OrderBy != null)
            {

                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDescending != null)
            {

                query = query.OrderByDescending(spec.OrderByDescending);
            }

            //Paginiation

            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }



            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;

        }
    }
}