using AutoMapper;
using init_api.Entities;
using init_api.Models;
namespace init_api.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductDto>()
                .ForMember(destinationMember=>destinationMember.Tags,
                           opt=>opt.MapFrom(sourceMember=>sourceMember.Tags));
            CreateMap<ProductAddDto,Product>();
            CreateMap<ProductDto,Product>();
        }
    }
}
