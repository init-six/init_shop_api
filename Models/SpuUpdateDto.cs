using System.ComponentModel.DataAnnotations;
namespace init_api.Models
{
    public class SpuUpdateDto{
        [Required]
        public string? Name{ get; set; }
        [Required]
        [Range(0,1)]
        public int Saleable { get; set; }
        [Range(0,1)]
        public int Valid { get; set; }
        public DateTime LastUpdateTime {get;set;}
        public SpuUpdateDto(){
            this.LastUpdateTime=DateTime.UtcNow;
        }
    }
}
