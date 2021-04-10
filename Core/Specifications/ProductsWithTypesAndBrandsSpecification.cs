using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParms)
        : base(x =>
           (string.IsNullOrEmpty(productParms.Search) || x.Name.ToLower().Contains(productParms.Search))
             &&
            (!productParms.BrandId.HasValue || x.ProductBrandId == productParms.BrandId)
             &&
            (!productParms.TypeId.HasValue || x.ProductTypeId == productParms.TypeId)

            )

        {

            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            //skip operation
            ApplyPaging(productParms.PageSize * (productParms.PageIndex - 1), productParms.PageSize);




            //which sorting do we want for the apropertiate key
            if (!string.IsNullOrEmpty(productParms.Sort))
            {
                switch (productParms.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;

                }
            }

        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);

        }
    }
}