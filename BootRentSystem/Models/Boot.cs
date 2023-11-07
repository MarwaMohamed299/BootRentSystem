namespace BootRentSystem.Models
{
    public class Boot
    {

        public Guid BootId { get; set; }

        public string BootName { get; set; } = string.Empty;

        public string Manufacturer { get; set; } = string.Empty;

        public int ProductionYear { get; set; }

      
        public bool IsAvailable { get; set; }

        public DateTime CreatedAt { get; set; }

        //NavProp

        public ICollection<Reservation> Reservations = new HashSet<Reservation>();

    }
}
