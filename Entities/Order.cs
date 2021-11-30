using System;
namespace init_api.Entities
{
    public class Order
    {
        public long Id { get; set; }

        public List<Product> Products { get; set; }
        
        public long UserId { get; set; }
        public User User { get; set; }

        public DateTime CreatTime { get; set; }
        public string Status { get; set; }
    }
}

