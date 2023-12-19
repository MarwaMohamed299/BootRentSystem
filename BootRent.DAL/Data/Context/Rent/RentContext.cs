using BootRent.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;


namespace BootRent.DAL.Data.Context.Rent
{
    public class RentContext : DbContext
    {
        public DbSet<Boot> Boots => Set<Boot>();
        public DbSet<Reservation> Reservations => Set<Reservation>();
        public DbSet<Package> Packages => Set<Package>();

        public RentContext(DbContextOptions<RentContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Boot
            modelBuilder.Entity<Boot>()
                .HasMany(boot => boot.Reservations);

            //Reservations
            modelBuilder.Entity<Reservation>()
                .HasOne(b => b.Boot)
                .WithMany(r => r.Reservations)
                .HasForeignKey(b => b.BootId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Reservation>()
                .HasOne(p => p.Package)
                .WithOne(P => P.Reservation)
                .HasForeignKey(p => p.PackageId)
                .OnDelete(DeleteBehavior.NoAction);
            


            #region Seeding

            var boots = new List<Boot>
            {
              new Boot {
                  Id =Guid.NewGuid(),
                  BootName="BootName1",
                  Manufacturer="Manufacturer1",
                  CreatedAt=new DateTime(2015, 12, 25),
                  IsAvailable=true,
                  ProductionYear=1999
                  },
              new Boot {
                  Id =Guid.NewGuid(),
                  BootName="BootName2",
                  Manufacturer="Manufacturer2",
                  CreatedAt=new DateTime(2018, 12, 25),
                  IsAvailable=true,
                  ProductionYear=2004
                  },
                new Boot {
                  Id =Guid.NewGuid(),
                  BootName="BootName1",
                  Manufacturer="Manufacturer1",
                  CreatedAt=new DateTime(2022, 12, 25),
                  IsAvailable=true,
                  ProductionYear=2009
                  },
            };
            var packages = new List<Package>
            {
                  new Package
                {
                    Id =Guid.NewGuid(),
                    PackageName="Birthday",
                    Price = 800.00m,
                    Description="Celebrate your birthday with style"

                },
                new Package
                {
                    Id = Guid.NewGuid(),
                    PackageName = "Birthday Package",
                    Price = 800.00m,
                    Description = "Celebrate your birthday with style"
                },
                new Package
                {
                    Id = Guid.NewGuid(),
                    PackageName = "Party Package",
                    Price = 1000.00m,
                    Description = "Perfect for hosting events and parties"
                },
                   new Package
                {
                    Id = Guid.NewGuid(),
                    PackageName = "Wedding Package",
                    Price = 1500.00m,
                    Description = "Perfect for weddings events and parties"
                }
            };

            var reservations = new List<Reservation>
            {
                new Reservation
                {
                    Id = Guid.NewGuid(),
                    BootId = boots[0].Id,
                     PackageId = packages[1].Id,
                    CheckInDate = DateTime.Now,
                    CheckOutDate = DateTime.Now.AddDays(15)
                },
                new Reservation
                {
                    Id = Guid.NewGuid(),
                    BootId = boots[1].Id,
                     PackageId = packages[2].Id,
                    CheckInDate = DateTime.Now,
                    CheckOutDate = DateTime.Now.AddDays(10)
                },
                new Reservation
                {
                    Id = Guid.NewGuid(),
                    BootId = boots[2].Id,
                    PackageId = packages[0].Id,
                    CheckInDate = DateTime.Now,
                    CheckOutDate = DateTime.Now.AddDays(20),
                   
                }
            };

            modelBuilder.Entity<Boot>().HasData(boots);
            modelBuilder.Entity<Package>().HasData(packages);
            modelBuilder.Entity<Reservation>().HasData(reservations);
        }
        #endregion
    }
}
