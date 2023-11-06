namespace BootRentSystem.Identity
{
    public class Address
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;


        //NavProp
        public string AppUserId { get; set; } = string.Empty;
        public AppUser? AppUser {get;  set;} 



    }
}