using System.ComponentModel.DataAnnotations;
namespace init_api.Models
{
    public class SpuUpdateDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        [Range(0, 1)]
        public byte Saleable { get; set; }
        [Range(0, 1)]
        public byte Valid { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public ICollection<SkuUpdateDto> Skus { get; set; } = new List<SkuUpdateDto>();
        public SpuDetailUpdateDto SpuDetail { get; set; }
        public SpuUpdateDto()
        {
            this.LastUpdateTime = DateTime.UtcNow;
        }
    }
}
