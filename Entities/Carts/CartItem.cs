using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using init_api.Entities.Product;
namespace init_api.Entities.Carts
{
    public class CartItem
    {
        [Column(TypeName = "bigint")]
        public Int64 Id { get; set; }
        [Comment("spu foreign key")]
        public Int64? fkSpuId { get; set; }
        [Comment("sku foreign key")]
        public Int64? fkSkuId { get; set; }
        public Int64? fkCartId { get; set; }
        [Comment("Money, value include cent")]
        public Int64 Price { get; set; }
        [Comment("Discount")]
        public byte Discount { get; set; }
        public Int64 Qty { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public String? context { get; set; }
        public Spu spu { get; set; } = new Spu();
        public Sku sku { get; set; } = new Sku();
        [Comment("is cart item active?")]
        public byte Active { get; set; }
        public Cart parent { get; set; } = new Cart();
    }
}
