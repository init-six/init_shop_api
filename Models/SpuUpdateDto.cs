using System.ComponentModel.DataAnnotations;
namespace init_api.Models
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
        public SpuUpdateDto()
        {
            this.LastUpdateTime = DateTime.UtcNow;
        }
    }
}
