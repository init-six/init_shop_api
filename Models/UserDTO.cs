namespace init_api.Models;

public class UserDTO
{
    public Guid UUID { get; set; }
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string? Role { get; set; }
    public long? TelNumber { get; set; }
    public string? Token { get; set; }
}
