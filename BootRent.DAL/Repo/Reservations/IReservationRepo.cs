using BootRent.DAL.Data.Models;
using BootRent.DAL.Repo.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootRent.DAL.Repo.Reservations
{
    public interface IReservationRepo : IGenericRepo<Reservation>
    {
        IEnumerable<Reservation> GetAllReservations();
        Reservation? GetReservationById(Guid id);
        void Add(Reservation reservation);
        void Update(Reservation reservation);
        void Delete(Reservation reservation);
        int SaveChanges();
    }

}
