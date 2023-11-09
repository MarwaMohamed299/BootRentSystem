using BootRent.DAL.Context.Rent;
using BootRent.DAL.Data.Models;
using BootRent.DAL.Repo.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootRent.DAL.Repo.Reservations
{
    public class ReservationRepo : GenericRepo<Reservation>, IReservationRepo
    {
        private readonly RentContext _rentContext;

        public ReservationRepo(RentContext rentContext) : base(rentContext)
        {
            _rentContext = rentContext;
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _rentContext.Set<Reservation>().ToList();
        }

        public Reservation? GetReservationById(Guid id)
        {
            return _rentContext.Set<Reservation>().Find(id);
        }

        public new void Add(Reservation reservation)
        {
            _rentContext.Set<Reservation>().Add(reservation);
        }

        public new void Update(Reservation reservation)
        {
            _rentContext.Set<Reservation>().Update(reservation);
        }

        public new void Delete(Reservation reservation)
        {
            _rentContext.Set<Reservation>().Remove(reservation);
        }

        public new int SaveChanges()
        {
            return _rentContext.SaveChanges();
        }
    }
}
