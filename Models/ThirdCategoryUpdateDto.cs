using System.ComponentModel.DataAnnotations;
namespace init_api.Models
{
    public class ThirdCategoryUpdateDto
    {
        [Required]
        public string? Name { get; set; }
        public string? Icon { get; set; }
    }
}
