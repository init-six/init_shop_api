using AutoMapper;
using init_api.Entities.Product;
using init_api.Models;
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
