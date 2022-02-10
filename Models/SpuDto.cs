using System.ComponentModel.DataAnnotations;
namespace init_api.Models
{
    public class SpuDto
    {
        public Guid UUID {get;set;}
        [Required]
        public string Name {get;set;}
        public int Saleable {get;set;}
        public int Valid {get;set;}
        public DateTime CreateTime {get;set;}
        public DateTime LastUpdateTime {get;set;}
    }
}
