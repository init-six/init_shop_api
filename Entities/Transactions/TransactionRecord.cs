using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using init_api.Entities.Order;
namespace init_api.Entities.Transactions
{
    [Comment("Transaction Record Table record all of the transaction info")]
    public class TransactionRecord
    {
        [Column(TypeName = "bigint")]
        public Int64 Id { get; set; }
        [Column(TypeName = "bigint")]
        public Int64 fkOrderId { get; set; }
        [Comment("transaction event details")]
        public string? Events { get; set; }
        [Comment("transaction result details")]
        public string? Result { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Orders orders { get; set; } = new Orders();
    }
}
