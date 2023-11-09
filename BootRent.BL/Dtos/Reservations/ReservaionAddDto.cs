using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootRent.BL.Dtos.Reservations
{
    public class ReservaionAddDto
    {
        public Guid ReservationId { get; set; }


        public DateTime CheckInDate { get; set; }


        public DateTime CheckOutDate { get; set; }
    }
}
