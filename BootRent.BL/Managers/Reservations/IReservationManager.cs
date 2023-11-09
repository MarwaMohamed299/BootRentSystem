using BootRent.BL.Dtos.Boots;
using BootRent.BL.Dtos.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BootRent.BL.Managers.Reservations
{
    public interface IReservationManager
    {
        IEnumerable<ReservationReadDto> GetAllReservations();
        ReservationReadDto? GetReservationById(Guid id);
        System.Guid Add(ReservationAddDto reservationAddDto);
        bool Update(ReservationUpdateDto reservationUpdateDto);
        bool Delete(Guid id);
    }
}
