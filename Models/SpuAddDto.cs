using System.ComponentModel.DataAnnotations;
namespace init_api.Models
{
    public class SpuAddDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [Range(0, 1)]
        public byte Saleable { get; set; }
        [Range(0, 1)]
        public byte Valid { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public ICollection<SkuAddDto> Skus { get; set; } = new List<SkuAddDto>();
        public SpuDetailAddDto SpuDetail { get; set; }
        public SpuAddDto()
        {
            this.Name = "undefined";
            this.Saleable = 1;
            this.Valid = 1;
            this.CreateTime = DateTime.UtcNow;
            this.LastUpdateTime = DateTime.UtcNow;
        }
    }
}
