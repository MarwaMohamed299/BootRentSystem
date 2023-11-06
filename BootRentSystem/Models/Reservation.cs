namespace BootRentSystem.Models
{
    public class Reservation
    {
        public Guid ReservationId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
