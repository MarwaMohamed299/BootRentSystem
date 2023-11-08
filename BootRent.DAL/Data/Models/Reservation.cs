namespace BootRent.DAL.Data.Models
{
    public class Reservation
    {
        public Guid ReservationId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        //NavProp
        public Guid BootId { get; set; }
        public Boot? Boot { get; set; }
    }
}
