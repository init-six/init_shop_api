using System.ComponentModel.DataAnnotations;
namespace init_api.Models
{
    public class SpuDto
    {
        public Guid UUID {get;set;}
        [Required]
        public string Name {get;set;}
        public byte Saleable {get;set;}
        public byte Valid {get;set;}
        public DateTime CreateTime {get;set;}
        public DateTime LastUpdateTime {get;set;}
    }
}
