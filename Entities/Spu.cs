using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using init_api.Entities.Order;

namespace init_api.Entities
{
    [Comment("Spu Table: Standard Product Unit")]
    public class Spu
    {
        [Column(TypeName = "bigint")]
        public Int64 Id { get; set; }
        public Guid UUID { get; set; }
        public string Name { get; set; }
        [Comment("first category")]
        public Guid? Ct1 { get; set; }
        [Comment("second category")]
        public Guid? Ct2 { get; set; }
        [Comment("third category")]
        public Guid? Ct3 { get; set; }
        [Comment("brand id")]
        public Int64? BrandId { get; set; }
        [Comment("0 offshore, 1 onshore; default 1;")]
        public byte Saleable { get; set; }
        [Comment("0 deleted, 1 valid; default: 1;")]
        public byte Valid { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public ICollection<Sku> Skus { get; set; } = new List<Sku>();
        public SpuDetail SpuDetail { get; set; } = new SpuDetail();
        public ICollection<OrderItem> orderitems { get; set; } = new List<OrderItem>();
        public Int64 Discount { get; set; }
        public Spu()
        {
            this.Name = "undefined";
            this.Saleable = 1;
            this.Valid = 1;
            this.CreateTime = DateTime.UtcNow;
            this.LastUpdateTime = DateTime.UtcNow;
            this.Discount = 100;
        }
    }
}
