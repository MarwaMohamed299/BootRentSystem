using BootRent.DAL.Data.DataTypes;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BootRent.DAL.Data.Models.Identity
{
    public class AppUser : IdentityUser
    {
        [StringLength(20, MinimumLength = 2)]

        public string DisplayName { get; set; } = string.Empty;
        public Address? Address { get; set; }
        public UserType UserType { get; set; }

    }
}
