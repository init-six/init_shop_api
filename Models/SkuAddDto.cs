using System.ComponentModel.DataAnnotations;
namespace init_api.Models
{
    public class SkuAddDto
    {
        public string? Name { get; set; }
        public string Image { get; set; } = string.Empty;
        public Int64 Price { get; set; }
        public string Indexes { get; set; } = string.Empty;
        public string OwnSpec { get; set; } = string.Empty;
        [Range(0, 1)]
        public byte Enable { get; set; }
        public SkuAddDto()
        {
            this.Name = "undefined";
            this.Price = 0;
            this.Enable = 1;
        }

    }
}
