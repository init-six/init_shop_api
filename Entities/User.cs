using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace init_api.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }
        public long TelNumber { get; set; }

        [InverseProperty("User")]
        public List<Order> Orders { get; set; }
    }


}

