namespace init_api.Models.Product
{
    public class StockAddDto
    {
        public Int16 SeckillStock { get; set; }
        public Int16 SeckillTotal { get; set; }
        public Int16 StockNum { get; set; }
        public StockAddDto()
        {
            this.SeckillStock = 0;
            this.SeckillTotal = 0;
            this.SeckillTotal = 0;
        }
    }
}
