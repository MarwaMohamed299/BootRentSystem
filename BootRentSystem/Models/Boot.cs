namespace BootRentSystem.Models
{
    public class Boot
    {

        public int BoatId { get; set; }

        public string BoatName { get; set; } = string.Empty;

        public string Manufacturer { get; set; } = string.Empty;

        public int ProductionYear { get; set; }

      
        public bool IsAvailable { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
