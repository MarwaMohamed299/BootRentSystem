using BootRentSystem.Identity;
using BootRentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using static System.Reflection.Metadata.BlobBuilder;

namespace BootRentSystem.Context.Rent
{
    public class RentContext : DbContext
    {
        public DbSet<Boot> Boots => Set<Boot>();
        public DbSet<Reservation> Reservations => Set<Reservation>();

        public RentContext( DbContextOptions<RentContext> options) :base (options)

        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Boot
            modelBuilder.Entity<Boot>().HasKey(B => B.BootId);
            modelBuilder.Entity<Boot>().HasMany(boot => boot.Reservations).WithOne(b => b.Boot)
                .HasForeignKey(b => b.BootId).OnDelete(DeleteBehavior.Cascade);

            //Reservations
            //
            modelBuilder.Entity<Reservation>().HasKey(r => r.ReservationId);
            modelBuilder.Entity<Reservation>().HasOne(b => b.Boot).WithMany(r => r.Reservations).
                HasForeignKey(b => b.BootId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Boot>().HasData(Boots);
            modelBuilder.Entity<Reservation>().HasData(Reservations);
        }
    

    }
}
