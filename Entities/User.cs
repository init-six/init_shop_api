using init_api.Entities.Order;
using System.ComponentModel.DataAnnotations.Schema;

namespace init_api.Entities
{
    public class User
    {
        [Column(TypeName = "bigint")]
        public Int64 Id { get; set; }
        public Guid UUID { get; set; }
        public string Email { get; set; }
        public string? UserName { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string? Role { get; set; }
        public long? mobile { get; set; }
        public ICollection<Orders> orders{ get; set; } = new List<Orders>();
        public User()
        {
            this.Role = "User";
            this.UserName = "Undefined";
        }
    }
}

