using System.ComponentModel.DataAnnotations;
namespace init_api.Models
{
    public class UserAddDto
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
