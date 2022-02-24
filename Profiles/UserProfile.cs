using AutoMapper;
using init_api.Entities;
using init_api.Models;
namespace init_api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
