
using System.ComponentModel.DataAnnotations;

namespace BootRent.DAL.Data.Models.Identity
{
    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;

        //        public UserType UserType { get;set; }


        //NavProp
        public string AppUserId { get; set; } = string.Empty;
        public AppUser? AppUser { get; set; }



    }
}