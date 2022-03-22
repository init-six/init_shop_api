using System.ComponentModel.DataAnnotations;
namespace init_api.Models.Category
{
    public class CategoryAddDto
    {
        [Required]
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public ICollection<SecCategoryAddDto> Children { get; set; } = new List<SecCategoryAddDto>();
    }
}
