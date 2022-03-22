using System.ComponentModel.DataAnnotations;
namespace init_api.Models;
public class UserDTO
{
    public Guid UUID { get; set; }
    [Required]
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string? Role { get; set; }
    public string? Mobile { get; set; }
    public string? Token { get; set; }
}
