using AutoMapper;
using init_api.Entities;
using init_api.Models;
namespace init_api.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category,CategoryDto>()
                .ForMember(destinationMember=>destinationMember.CategoryName,
                           opt=>opt.MapFrom(sourceMember=>sourceMember.Name));
        }
    }
}