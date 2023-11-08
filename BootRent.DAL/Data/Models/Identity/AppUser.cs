using BootRent.DAL.Data.DataTypes;
using Microsoft.AspNetCore.Identity;

namespace BootRent.DAL.Data.Models.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; } = string.Empty;
        public Address? Address { get; set; }
        public UserType UserType { get; set; }

    }
}
