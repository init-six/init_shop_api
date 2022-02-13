namespace init_api.Models
{
    public class ProductDto
    {
        public Guid UUID { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? PictureURL { get; set; }
        public string? VideoURL { get; set; }
        public string[]? Tags { get; set; }
    }
}
