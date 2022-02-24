namespace init_api.Entities
{
    public class User
    {
        public long Id { get; set; }
        public Guid UUID { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string? Role { get; set; }
        public long? TelNumber { get; set; }
        public User()
        {
            this.Role = "User";
            this.UserName = "Undefined";
        }
    }
}

