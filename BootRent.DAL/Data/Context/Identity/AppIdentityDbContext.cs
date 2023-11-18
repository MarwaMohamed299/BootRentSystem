using BootRent.DAL.Data.DataTypes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AppUser = BootRent.DAL.Data.Models.Identity.AppUser;

namespace BootRent.DAL.Data.Context.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {

        public DbSet<AppUser> appUsers => Set<AppUser>();
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>().HasKey(X => X.Id);





            #region Seeding
            var appUsers = new List<AppUser> {


            new AppUser
            {
                DisplayName = "MarwaMohamed",
                Id = Guid.NewGuid().ToString(),
                UserType = UserType.Admin,
                  FirstName = "Marwa",
                        LastName = "Mohamed",
                        City = "Egypt",
                        State = "Cairo",
                        Street = "ALGomhorya",
                        ZipCode = "4521",
                         Password = "jndjvijikgkf@2153",
                        E_mail = "Marwa@gmail.com"





            },
            new AppUser
            {
                DisplayName = "SaraZaki",
                Id = Guid.NewGuid().ToString(),
                UserType = UserType.User,
                   FirstName = "Sara",
                        LastName = "Zaki",

                        City = "Egypt",
                        State = "Alex",
                        Street = "ALGomhorya",
                        ZipCode = "276",
                        Password = "jnjvkf@2153",
                        E_mail = "Sara@gmail.com"



        },
              new AppUser
            {
                DisplayName = "MohamedSamy",
                Id = Guid.NewGuid().ToString(),
                UserType = UserType.BootOwner,
                     FirstName = "Mohamed",
                        LastName = "Samy",

                        City = "Egypt",
                        State = "NorthCoast",
                        Street = "ALGomhorya",
                        ZipCode = "135",
                        Password = "jndjvkf@2153",
                        E_mail = "Mohamed@gmail.com"



        }
    };
            #endregion


            modelBuilder.Entity<AppUser>().HasData(appUsers);

        }


    }
}
