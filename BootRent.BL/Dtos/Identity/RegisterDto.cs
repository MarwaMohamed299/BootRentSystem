
using BootRent.DAL.Data.DataTypes;

namespace BootRent.BL.Dtos.Identity
{
    public class RegisterDto
    {
        public string UserName { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;

        public UserType UserType { get; set; }
    }
}
