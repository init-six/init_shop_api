using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace init_api.Entities.Order
{
    public class OrderItem
    {
        [Column(TypeName = "bigint")]
        public Int64 Id { get; set; }
        [Comment("spu foreign key")]
        public Int64? fkSpuId { get; set; }
        [Comment("sku foreign key")]
        public Int64? fkSkuId { get; set; }
        public Int64? fkOrderId { get; set; }
        [Comment("Money, value include cent")]
        public Int64 Price { get; set; }
        [Comment("Discount")]
        public byte Discount { get; set; }
        public Int64 Qty { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public String? context { get; set; }
        public Orders parent { get; set; } = new Orders();
        public Spu spu { get; set; } = new Spu();
        public Sku sku { get; set; } = new Sku();
    }
}
