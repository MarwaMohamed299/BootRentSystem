
namespace BootRent.DAL.Data.Models
{
    public class Package
    {
        public Guid Id { get; set; }
        public string PackageName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        //NavProp
        public Reservation? Reservation { get; set; }
        public Guid ReservationId { get; set; } 

    }
}
