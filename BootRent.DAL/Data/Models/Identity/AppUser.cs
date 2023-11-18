using BootRent.DAL.Data.DataTypes;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BootRent.DAL.Data.Models.Identity
{
    public class AppUser : IdentityUser
    {
        [StringLength(20, MinimumLength = 2)]

        public string DisplayName { get; set; } = string.Empty;
        public UserType UserType { get; set; }

        public string FirstName { get; set; } = string.Empty;
        [StringLength(20, MinimumLength = 2)]

        public string LastName { get; set; } = string.Empty;
        [StringLength(20, MinimumLength = 2)]

        public string City { get; set; } = string.Empty;
        [EmailAddress]
        public string E_mail { get; set; } = string.Empty;

        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one letter and one digit.")]
        public string Password { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;



    }
}
