using System;

namespace init_api.Entities
{
    public class Category
    {
        public long Id { get; set; }
        public Guid PId {get;set;}
        public string? Name {get;set;}
        public string? Icon {get;set;}
        public ICollection<Category> Categories{get;set;}
        public ICollection<Product> Products {get;set;}
    }
}