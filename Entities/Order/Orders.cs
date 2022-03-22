using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace init_api.Entities.Order
{
    public class Orders
    {
        [Column(TypeName = "bigint")]
        public Int64 Id { get; set; }
        [Column(TypeName = "bigint")]
        public Int64 UserId { get; set; }
        public String? sessionId { get; set; }
        public String? token { get; set; }
        [Comment("order status. 0:unpaid 1:paid 2:delivered 3:signed. -1:apply return -2:during return -3:returned goods -4: cancel return")]
        public String? orderStatus { get; set; }
        [Comment("after status. 0:no feedback 1: apply after service -1:cancel after service 2: process 200:done")]
        public String? afterStatus { get; set; }
        [Comment("product total")]
        public Int64 productTotal { get; set; }
        [Comment("actual paid total")]
        public Int64 orderAmountTotal { get; set; }
        [Comment("logistics Fee")]
        public Int64 logisticsFee { get; set; }
        [Comment("pay channel: offline, cash on delivery, cheque, draft, online")]
        public String? payChannel { get; set; }
        [Comment("order trade number")]
        public String? outTadeNo { get; set; }
        [Comment("third party trade number")]
        public String? escrowTradeNo { get; set; }
        [Comment("discount code")]
        public String? promo { get; set; }
        public String? userName { get; set; }
        public String? mobile { get; set; }
        public String? email { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        [Comment("0 unpaid, 1 paid; default: 0;")]
        public byte orderSettlementStatus { get; set; }
        public String? context { get; set; }
        [Comment("buyer")]
        public User user { get; set; } = new User();
        public ICollection<OrderItem> items {get;set;}=new List<OrderItem>();
        //TODO miss supplier table 
        //TODO afterstatus should apply to each OrderItem
        public Orders()
        {
            this.orderSettlementStatus = 0;
        }
    }
}

