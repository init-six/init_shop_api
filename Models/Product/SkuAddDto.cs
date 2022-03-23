using System.ComponentModel.DataAnnotations;
namespace init_api.Models.Product
{
    public class SkuAddDto
    {
        public string? Name { get; set; }
        public string[]? Images { get; set; }
        public Int64 Price { get; set; }
        public string Indexes { get; set; } = string.Empty;
        public string OwnSpec { get; set; } = string.Empty;
        [Range(0, 1)]
        public byte Enable { get; set; }
        public StockAddDto Stock { get; set; } = new StockAddDto();
        public SkuAddDto()
        {
            this.Name = "undefined";
            this.Price = 0;
            this.Enable = 1;
        }

    }
}
