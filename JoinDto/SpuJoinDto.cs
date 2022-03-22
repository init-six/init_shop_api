using System.ComponentModel.DataAnnotations;
using init_api.Entities;
namespace init_api.JoinDto
{
    public class SpuJoinDto
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
        public SpuDetail SpuDetail { get; set; } = new SpuDetail();
        public Int64 Discount { get; set; }
        public ICollection<Sku> Skus { get; set; } = new List<Sku>();
    }
}
