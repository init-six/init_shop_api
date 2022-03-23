using System.ComponentModel.DataAnnotations;
namespace init_api.Models.Product
{
    public class SpuUpdateDto
    {
        [Required]
        public string? Name { get; set; }
        public Guid? Ct1 { get; set; }
        public Guid? Ct2 { get; set; }
        public Guid? Ct3 { get; set; }
        [Required]
        [Range(0, 1)]
        public byte Saleable { get; set; }
        [Range(0, 1)]
        public byte Valid { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public SpuDetailUpdateDto SpuDetail { get; set; } = new SpuDetailUpdateDto();
        [Range(0, 100)]
        public Int64 Discount { get; set; }
        public SpuUpdateDto()
        {
            this.LastUpdateTime = DateTime.UtcNow;
        }
    }
}
