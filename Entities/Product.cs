namespace init_api.Entities
{
    public class Product
    {
        public long Id {get;set;}
        public Guid UUID { get; set; }
        public Guid CategoryId {get;set;}
        public long FkCategoryId{get;set;}
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? PictureURL { get; set; }
        public string? VideoURL { get; set; }

        public string? Tags {get;set;}
        public Category Category{get;set;}

        public Product()
        {
            this.Name = "undefined";
        }
    }
}

