
using BootRent.DAL.Data.DataTypes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Address = BootRent.DAL.Data.Models.Identity.Address;
using AppUser = BootRent.DAL.Data.Models.Identity.AppUser;

namespace BootRent.DAL.Context.Identity
{
    public class AppIdentityDbContext :IdentityDbContext<AppUser>
    {

        public DbSet<AppUser> appUsers => Set<AppUser>();
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) :base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>().HasKey(X => X.Id);
            modelBuilder.Entity<AppUser>().HasOne(A => A.Address).WithOne(A => A.AppUser).
                HasForeignKey<Address>(x => x.AppUserId).
                OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Address>().HasKey(X => X.AddressId);

            #region Seeding
            var appUsers = new List<AppUser> {


            new AppUser
            {
                DisplayName = "MarwaMohamed",
                Id = Guid.NewGuid().ToString(),
                UserType = UserType.Admin


            },
            new AppUser
            {
                DisplayName = "SaraZaki",
                Id = Guid.NewGuid().ToString(),
                UserType = UserType.User



        },
              new AppUser
            {
                DisplayName = "MohamedSamy",
                Id = Guid.NewGuid().ToString(),
                UserType = UserType.BootOwner



        }
    };
            #endregion

            var addresses = new List<Address>
            { 
                new Address

                    {
                        FirstName = "Marwa",
                        LastName = "Mohamed",
                        AddressId =  Guid.NewGuid(),
                        AppUserId = appUsers[0].Id,
                        City = "Egypt",
                        State = "Cairo",
                        Street = "ALGomhorya",
                        ZipCode = "4521",


                    },
                 new Address

                    {
                        FirstName = "Sara",
                        LastName = "Zaki",
                        AddressId =  Guid.NewGuid(),
                        AppUserId =  appUsers[1].Id,
                        City = "Egypt",
                        State = "Alex",
                        Street = "ALGomhorya",
                        ZipCode = "276",


                    },new Address

                    {
                        FirstName = "Mohamed",
                        LastName = "Samy",
                        AddressId =  Guid.NewGuid(),
                        AppUserId = appUsers[2].Id,
                        City = "Egypt",
                        State = "NorthCoast",
                        Street = "ALGomhorya",
                        ZipCode = "135",
                       


                    },

            };
            modelBuilder.Entity<AppUser>().HasData(appUsers);
            modelBuilder.Entity<Address>().HasData(addresses);

        }


    }
}
