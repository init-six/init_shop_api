using System.ComponentModel.DataAnnotations;
namespace init_api.Models
{
    public class SpuUpdateSaleAbleDto
    {
        [Required]
        [Range(0, 1)]
        public byte Saleable { get; set; }
    }
}
