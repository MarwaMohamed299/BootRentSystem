using BootRent.BL.Dtos.Boots;
using BootRent.BL.Dtos.Reservations;
using BootRent.DAL.Data.Models;
using BootRent.DAL.Repo.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootRent.BL.Managers.Reservations
{
    public class ReservationManager :IReservationManager
    {
        private readonly IReservationRepo _reservationRepo;

        public ReservationManager(IReservationRepo reservationRepo)
        {
            _reservationRepo = reservationRepo;
        }
        public Guid Add(ReservationAddDto reservationFromRequest)             //Add
        {
           Reservation? reservation = new Reservation
            {

                CheckInDate = reservationFromRequest.CheckInDate,
               CheckOutDate = reservationFromRequest.CheckOutDate,
               BootId = reservationFromRequest.BootId,
               ReservationId=reservationFromRequest.ReservationId

               

            };
            _reservationRepo.Add(reservation);
            _reservationRepo.SaveChanges();
            return reservation.ReservationId;

        }

        public bool Delete(Guid id)                                     //Delete
        {
            Reservation? reservation = _reservationRepo.GetReservationById(id);
            if (reservation == null)
            {
                return false;
            }
            _reservationRepo.Delete(reservation);

            _reservationRepo.SaveChanges();
            return true;
        }

        public IEnumerable<ReservationReadDto> GetAllReservations()                   //GetAll
        {
            IEnumerable<Reservation> reservationsFromDb = _reservationRepo.GetAllReservations();
            return reservationsFromDb.Select(R => new ReservationReadDto
            {
                CheckInDate = R.CheckInDate,
                CheckOutDate = R.CheckOutDate,
                BootId =  R.BootId,
                ReservationId=R.ReservationId


            });
        }
      

        public ReservationReadDto? GetReservationById(Guid id)            //GetById
        {
            Reservation? reservationFromDb = _reservationRepo.GetReservationById(id);
            if (reservationFromDb == null)
            {
                return null;
            }
            return new ReservationReadDto
            {
                CheckInDate = reservationFromDb.CheckInDate,
                CheckOutDate=reservationFromDb.CheckOutDate,
                ReservationId=reservationFromDb.ReservationId,
                BootId=reservationFromDb.BootId
            };
        }

        public bool Update(ReservationUpdateDto reservationFromRequest)        //Update
        {
            Reservation? reservation = _reservationRepo.GetReservationById(reservationFromRequest.ReservationId);
            if (reservation == null)
            {
                return false;
            }
            reservation.CheckInDate = reservationFromRequest.CheckInDate;
            reservation.CheckOutDate = reservationFromRequest.CheckOutDate;
            reservation.ReservationId = reservation.BootId;
          
            _reservationRepo.Update(reservation);
            _reservationRepo.SaveChanges();
            return true;
        }
    }
}
