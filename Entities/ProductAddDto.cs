namespace init_api.Entities
{
    public class ProductAddDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? PictureURL { get; set; }
        public string? VideoURL { get; set; }
        public string? Tags {get;set;}
        public ProductAddDto(){
            this.Name="undefined";
        }
    }
}

