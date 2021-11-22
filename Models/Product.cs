using System;
namespace init_api.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public long Price { get; set; }
        public int Stock { get; set; }
        public string? PictureURL { get; set; }

        public Product()
        {
            this.Name = "undefined";
        }
    }
}

