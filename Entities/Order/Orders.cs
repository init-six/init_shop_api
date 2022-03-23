using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using init_api.Entities.Transactions;
namespace init_api.Entities.Order
{
    public class Orders
    {
        [Column(TypeName = "bigint")]
        public Int64 Id { get; set; }
        [Column(TypeName = "bigint")]
        public Int64 UserId { get; set; }
        public String? SessionId { get; set; }
        public String? Token { get; set; }
        [Comment("order status. 0:unpaid 1:paid 2:delivered 3:signed. -1:apply return -2:during return -3:returned goods -4: cancel return")]
        public byte OrderStatus { get; set; }
        [Comment("after status. 0:no feedback 1: apply after service -1:cancel after service 2: process 200:done")]
        public byte AfterStatus { get; set; }
        [Comment("Discount")]
        public byte Discount { get; set; }
        [Comment("sub total")]
        public Int64 SubTotal { get; set; }
        [Comment("product total")]
        public Int64 Total { get; set; }
        [Comment("actual paid total")]
        public Int64 OrderAmountTotal { get; set; }
        [Comment("logistics Fee")]
        public Int64 LogisticsFee { get; set; }
        [Comment("pay channel: offline, cash on delivery, cheque, draft, online,wechat,stripe...")]
        public byte PayChannel { get; set; }
        [Comment("order trade number")]
        public String? OutTadeNo { get; set; }
        [Comment("third party trade number")]
        public String? EscrowTradeNo { get; set; }
        [Comment("discount code")]
        public String? Promo { get; set; }
        public String? UserName { get; set; }
        public String? Mobile { get; set; }
        public String? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [Comment("0 unpaid, 1 paid; default: 0;")]
        public byte OrderSettlementStatus { get; set; }
        public String? Context { get; set; }
        [Comment("buyer")]
        public User user { get; set; } = new User();
        public ICollection<OrderItem> items { get; set; } = new List<OrderItem>();
        //TODO miss supplier table 
        //TODO afterstatus should apply to each OrderItem
        public Address address { get; set; } = new Address();
        public Transaction transaction { get; set; } = new Transaction();
        public TransactionRecord transactionRecord { get; set; } = new TransactionRecord();
        public Orders()
        {
            this.OrderSettlementStatus = 0;
        }
    }
}

