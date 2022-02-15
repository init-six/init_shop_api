using AutoMapper;
using init_api.Entities;
using init_api.Models;
namespace init_api.Profiles
{
    public class SpuDetailProfile : Profile
    {
        public SpuDetailProfile()
        {
            CreateMap<SpuDetailAddDto, SpuDetail>();
            CreateMap<SpuDetailUpdateDto, SpuDetail>();
            CreateMap<SpuDetail, SpuDetailDto>();
        }
    }
}
