using BootRent.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace BootRent.DAL.Context.Rent
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

           
        }
    

    }
}
