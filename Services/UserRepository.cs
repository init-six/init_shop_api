using Microsoft.EntityFrameworkCore;
using init_api.Data;
using init_api.Entities;
namespace init_api.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ShopContext _context;
        public UserRepository(ShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> GetUserAsync(Guid userUUID)
        {
            if (userUUID == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userUUID));
            }
            return await _context.Users.FirstOrDefaultAsync(x => x.UUID == userUUID) ?? new User();
        }

        public async Task<User> GetUserAsync(String email)
        {
            if (email == string.Empty)
            {
                throw new ArgumentNullException(nameof(email));
            }
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email.ToLower().Trim()) ?? new User();
        }

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.UUID = Guid.NewGuid();
            _context.Users.Add(user);
        }

        public void UpdateUser(User user)
        {

        }

        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Remove(user);
        }

        public async Task<bool> UserExistAsync(Guid userUUID)
        {
            if (userUUID == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userUUID));
            }
            return await _context.Users.AnyAsync(x => x.UUID == userUUID);
        }

        public async Task<bool> UserExistAsync(String email)
        {
            if (email == String.Empty)
            {
                throw new ArgumentNullException(nameof(email));
            }
            return await _context.Users.AnyAsync(x => x.Email == email.ToLower().Trim());
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
