using System.ComponentModel.DataAnnotations;
namespace init_api.Models
{
    public class UserUpdateDto
    {
        [Required]
        public string? UserName { get; set; }
        public string? Mobile { get; set; }
    }
}
