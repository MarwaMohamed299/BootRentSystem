using BootRent.DAL.Data.Context.Identity;
using BootRent.DAL.Data.Context.Rent;
using BootRent.DAL.Repo.Boots;
using BootRent.DAL.Repo.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootRent.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
 

        public IBootRepo? BootRepo { get; }
        public IReservationRepo? ReservationRepo { get; }



        private readonly AppIdentityDbContext _appIdentityDbContext;
        private readonly RentContext _rentContext;


       
        public UnitOfWork(AppIdentityDbContext appIdentityDbContext, RentContext rentContext, IBootRepo bootRepo, IReservationRepo reservationRepo)
        {
            _appIdentityDbContext = appIdentityDbContext;
            _rentContext = rentContext;
            BootRepo = bootRepo;
            ReservationRepo = reservationRepo;
        }
        public async Task<int> Save()
        {
            int rentContextChanges = await _rentContext.SaveChangesAsync();
            int appIdentityDbContextChanges = await _appIdentityDbContext.SaveChangesAsync();

            return rentContextChanges + appIdentityDbContextChanges;
        }

    }
}
