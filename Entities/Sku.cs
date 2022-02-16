using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace init_api.Entities
{
    [Comment("Sku Table: Stock Keeping Unit")]
    public class Sku
    {
        [Column(TypeName = "bigint")]
        public Int64 Id { get; set; }
        public Guid UUID { get; set; }
        [Comment("spu foreign key")]
        public Int64? fkSpuId { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        [Comment("Money, value include cent")]
        public Int64 Price { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Indexes { get; set; } = string.Empty;
        [Column(TypeName = "varchar(1000)")]
        public string OwnSpec { get; set; } = string.Empty;
        [Comment("IsValid? 0=not valid, 1=valid")]
        public byte Enable { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public Spu Spu { get; set; } = new Spu();
        public Stock Stock { get; set; } = new Stock();
        public Sku()
        {
            this.Name = "undefined";
            this.Enable = 1;
            this.CreateTime = DateTime.UtcNow;
            this.LastUpdateTime = DateTime.UtcNow;
        }
    }
}
