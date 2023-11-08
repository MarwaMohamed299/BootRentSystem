using System.ComponentModel.DataAnnotations;

namespace BootRent.DAL.Data.Models
{
    public class Reservation
    {
        public Guid ReservationId { get; set; }

        [Required(ErrorMessage = "CheckInDate is required.")]
        [DataType(DataType.DateTime)]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "CheckOutDate is required.")]
        [DataType(DataType.DateTime)]
        public DateTime CheckOutDate { get; set; }

        //NavProp
        public Guid BootId { get; set; }
        public Boot? Boot { get; set; }
    }
}
