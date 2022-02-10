using System.ComponentModel.DataAnnotations;
namespace init_api.Models
{
    public class ProductUpdateDto
    {
        [Required]
        [MaxLength(200)]
        public string? Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? PictureURL { get; set; }
        public string? VideoURL { get; set; }
        public string? Tags {get;set;}
    }
}
