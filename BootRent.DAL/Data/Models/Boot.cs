using System.ComponentModel.DataAnnotations;

namespace BootRent.DAL.Data.Models
{
    public class Boot
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = "BootName is required.")]
        public string BootName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Manufacturer is required.")]
        public string Manufacturer { get; set; } = string.Empty;

        [Range(1800, int.MaxValue, ErrorMessage = "ProductionYear must be greater than or equal to 1800.")]
        public int ProductionYear { get; set; }

        public bool IsAvailable { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        //NavProp

        public ICollection<Reservation> Reservations = new HashSet<Reservation>();

    }



}
