using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace init_api.Entities
{
    [Comment("Stock: describe total stock for each sku table")]
    public class Stock
    {
        [Column(TypeName = "bigint")]
        public Int64 Id { get; set; }
        [Column(TypeName = "bigint")]
        public Int64 fkSkuId { get; set; }
        [Comment("Seckilling Stock Number")]
        public Int16 SeckillStock { get; set; }
        [Comment("Seckilling Total Number")]
        public Int16 SeckillTotal { get; set; }
        [Comment("Stock Number")]
        public Int16 StockNum { get; set; }
        //#TODO Stocku And Sku is One To One. And always linked
        public Sku Sku { get; set; }
        public Stock()
        {
            this.SeckillStock = 0;
            this.SeckillTotal = 0;
            this.StockNum = 0;
        }
    }
}
