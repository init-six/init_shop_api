using System;

namespace init_api.Models
{
    public class CategoryAddDto{
        public string Name{get;set;}
        public string Icon {get;set;}
        public ICollection<ProductAddDto> Products {get;set;} = new List<ProductAddDto>();
    }
}
