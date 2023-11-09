using BootRent.DAL.Repo.Boots;
using BootRent.DAL.Repo.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootRent.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IBootRepo BootRepo { get; }
        public IReservationRepo ReservationRepo{ get; }
         Task<int> Save();

    }
}
