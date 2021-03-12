using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            /*
            CreateMap matches the ProductToReturnDto to Product.cs

            We use ForMember
            because product.cs  getter and setter for ProductType/ProductBrand is a return type class
            and     productToReturnDto.cs getter and setters 
            CAN'T MATCH A STRING TO A CLASS

            So we use ForMember to help us out.

            Strange syntax....
            */
            CreateMap<Product, ProductToReturnDto>()
            .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
            .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}