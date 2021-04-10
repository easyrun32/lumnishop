using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        //where criteria is
        Expression<Func<T, bool>> Criteria { get; }

        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }


        Expression<Func<T, object>> OrderByDescending { get; }


        int Take { get; }


        //we can skip a certain amount of products      
        int Skip { get; }

        bool IsPagingEnabled { get; }

    }
}