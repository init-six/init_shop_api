using System.ComponentModel.DataAnnotations;
namespace init_api.Models
{
    public class CategoryAddDto
    {
        [Required(ErrorMessage = "{0} is Required")]
        [MaxLength(100, ErrorMessage = "{0} Max Length is {1}")]
        public string Name { get; set; }
        public string? Icon { get; set; }
        public ICollection<ProductAddDto> Products { get; set; } = new List<ProductAddDto>();
    }
}
