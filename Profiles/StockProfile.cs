using AutoMapper;
using init_api.Entities.Product;
using init_api.Models.Product;
namespace init_api.Profiles
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<StockAddDto, Stock>();
            CreateMap<StockUpdateDto, Stock>();
            CreateMap<Stock, StockDto>();
        }
    }
}
