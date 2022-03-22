namespace init_api.Models.Category
{
    public class CategoryDto
    {
        public Guid UUID { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public ICollection<SecCategoryDto> Children { get; set; } = new List<SecCategoryDto>();
    }
}
