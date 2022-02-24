using init_api.Entities;

namespace init_api.Services
{
    public interface IUserRepository
    {
        //Get User Through UUID
        Task<User> GetUserAsync(Guid userId);
        //Get User Through Email
        Task<User> GetUserAsync(String email);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        Task<bool> UserExistAsync(Guid userId);
        Task<bool> UserExistAsync(String email);

        Task<bool> SaveAsync();
    }
}
