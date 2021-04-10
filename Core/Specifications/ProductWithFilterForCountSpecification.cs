using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithFilterForCountSpecification : BaseSpecification<Product>
    {
        public ProductsWithFilterForCountSpecification(ProductSpecParams productParms)
        : base(x =>
              (string.IsNullOrEmpty(productParms.Search) || x.Name.ToLower().Contains(productParms.Search)) &&
              (!productParms.BrandId.HasValue || x.ProductBrandId == productParms.BrandId)
              && (!productParms.TypeId.HasValue || x.ProductTypeId == productParms.TypeId)
            )
        {

        }

    }
}