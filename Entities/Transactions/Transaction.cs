using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using init_api.Entities.Order;
namespace init_api.Entities.Transactions
{
    [Comment("Transaction table map with user and orders by one-to-one")]
    public class Transaction
    {
        [Column(TypeName = "bigint")]
        public Int64 Id { get; set; }
        [Column(TypeName = "bigint")]
        public Int64 fkUserId { get; set; }
        [Column(TypeName = "bigint")]
        public Int64 fkOrderId { get; set; }
        [Comment("Payment Status: -1: cancel. 0: uncompleted. 1:completed. -2:error. New,Cancelled,Failed,Pending,Declined,Rejected, and Success")]
        public byte PayStatus { get; set; }
        [Comment("PaymentId provided by the payment gateway.")]
        public string? Code { get; set; }
        public DateTime CompletionTime { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User user { get; set; } = new User();
        public Orders orders { get; set; } = new Orders();
    }
}
