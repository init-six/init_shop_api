using AutoMapper;
using init_api.Entities.Category;
using init_api.Models.Category;
namespace init_api.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryAddDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();

            CreateMap<SecCategory, SecCategoryDto>();
            CreateMap<SecCategoryAddDto, SecCategory>();
            CreateMap<SecCategoryUpdateDto, SecCategory>();

            CreateMap<ThirdCategory, ThirdCategoryDto>();
            CreateMap<ThirdCategoryAddDto, ThirdCategory>();
            CreateMap<ThirdCategoryUpdateDto, ThirdCategory>();
        }
    }
}
