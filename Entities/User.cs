using init_api.Entities.Order;
using System.ComponentModel.DataAnnotations.Schema;
using init_api.Entities.Transactions;
using System.ComponentModel.DataAnnotations;

namespace init_api.Entities
{
    public class User
    {
        [Column(TypeName = "bigint")]
        public Int64 Id { get; set; }
        [Required]
        public Guid UUID { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public byte[]? PasswordHash { get; set; }
        [Required]
        public byte[]? PasswordSalt { get; set; }
        public string? Role { get; set; }
        public string? Mobile { get; set; }
        public ICollection<Orders> orders { get; set; } = new List<Orders>();
        public Transaction transaction { get; set; } = new Transaction();
        public User()
        {
            this.Role = "User";
            this.UserName = "Undefined";
        }
    }
}

