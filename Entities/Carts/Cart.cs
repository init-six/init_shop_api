using System.ComponentModel.DataAnnotations.Schema;
namespace init_api.Entities.Carts
{
    public class Cart
    {
        [Column(TypeName = "bigint")]
        public Int64 Id { get; set; }
        [Column(TypeName = "bigint")]
        public Int64 UserId { get; set; }
        public String? SessionId { get; set; }
        public String? Token { get; set; }
        public String? UserName { get; set; }
        public String? Mobile { get; set; }
        public String? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public String? Context { get; set; }
        public Address address { get; set; } = new Address();
        public User user { get; set; } = new User();
        public ICollection<CartItem> cartItems { get; set; } = new List<CartItem>();
    }
}
