using System.ComponentModel.DataAnnotations;
namespace init_api.Models.Product
{
    public class SkuDto
    {
        public Int64 Id { get; set; }
        public Guid UUID { get; set; }
        public string? Name { get; set; }
        public string[]? Images { get; set; }
        public Int64 Price { get; set; }
        public string? Indexes { get; set; }
        public string? OwnSpec { get; set; }
        public byte Enable { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public StockDto Stock { get; set; } = new StockDto();
    }
}
