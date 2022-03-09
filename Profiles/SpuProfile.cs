using AutoMapper;
using init_api.Entities;
using init_api.Models;
namespace init_api.Profiles
{
    public class SpuProfile : Profile
    {
        public SpuProfile()
        {
            CreateMap<Spu, SpuDto>();
            CreateMap<SpuAddDto, Spu>();
            CreateMap<SpuUpdateDto, Spu>();
            CreateMap<SpuUpdateSaleAbleDto, Spu>();
        }
    }
}
