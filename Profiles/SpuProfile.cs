using AutoMapper;
using init_api.Entities.Product;
using init_api.Models;
using init_api.JoinDto;
namespace init_api.Profiles
{
    public class SpuProfile : Profile
    {
        public SpuProfile()
        {
            CreateMap<Spu, SpuDto>();
            CreateMap<SpuJoinDto, SpuDto>();
            CreateMap<SpuAddDto, Spu>();
            CreateMap<SpuUpdateDto, Spu>();
            CreateMap<SpuUpdateSaleAbleDto, Spu>();
        }
    }
}
