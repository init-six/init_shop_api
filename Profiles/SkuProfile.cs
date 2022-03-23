using AutoMapper;
using init_api.Entities.Product;
using init_api.Models;
namespace init_api.Profiles
{
    public class SkuProfile : Profile
    {
        public SkuProfile()
        {
            CreateMap<Sku, SkuDto>();
            CreateMap<SkuAddDto, Sku>();
            CreateMap<SkuUpdateDto, Sku>();
        }
    }
}
