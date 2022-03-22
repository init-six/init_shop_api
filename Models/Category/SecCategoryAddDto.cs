using System.ComponentModel.DataAnnotations;
namespace init_api.Models.Category
{
    public class SecCategoryAddDto
    {
        [Required]
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public Guid UUID { get; set; }
        [Required]
        public Guid ParentUUID { get; set; }
        public ICollection<ThirdCategoryAddDto> Children { get; set; } = new List<ThirdCategoryAddDto>();
    }
}
