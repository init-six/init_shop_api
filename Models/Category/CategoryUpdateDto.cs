using System.ComponentModel.DataAnnotations;
namespace init_api.Models.Category
{
    public class CategoryUpdateDto
    {
        [Required]
        public string? Name { get; set; }
        public string? Icon { get; set; }
    }
}
