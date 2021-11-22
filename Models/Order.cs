using System;
namespace init_api.Models
{
    public class Order
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public enum Status { processing, shipped, delivered, completed}

        public Order()
        {
        }
    }
}

