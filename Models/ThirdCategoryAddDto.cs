using System.ComponentModel.DataAnnotations;
namespace init_api.Models
{
    public class ThirdCategoryAddDto
    {
        [Required]
        public Guid UUID { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        [Required]
        public Guid ParentUUID { get; set; }
    }
}
