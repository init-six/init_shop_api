namespace init_api.Models
{
    public class SecCategoryDto
    {
        public Guid UUID { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public ICollection<ThirdCategoryDto> Children { get; set; } = new List<ThirdCategoryDto>();
    }
}
