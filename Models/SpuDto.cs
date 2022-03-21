using System.ComponentModel.DataAnnotations;
namespace init_api.Models
{
    public class SpuDto
    {
        public Guid UUID { get; set; }
        public Int64 Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public Guid? Ct1 { get; set; }
        public Guid? Ct2 { get; set; }
        public Guid? Ct3 { get; set; }
        public String? FirstCategory { get; set; }
        public String? SecCategory { get; set; }
        public String? ThirdCategory { get; set; }
        public byte Saleable { get; set; }
        public byte Valid { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public ICollection<SkuDto> Skus { get; set; } = new List<SkuDto>();
        public SpuDetailDto SpuDetail { get; set; } = new SpuDetailDto();
    }
}
