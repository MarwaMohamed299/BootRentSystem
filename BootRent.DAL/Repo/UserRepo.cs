using BootRent.DAL.Data.Context.Identity;
using BootRent.DAL.Data.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootRent.DAL.Repo
{
    public  interface IUserRepo
    {
       Task<int> RetrieveEmailWithOTP(int otp);
        Task<int> SaveChangesAsync();
    }
    public class UserRepo : IUserRepo
    {
        private readonly AppIdentityDbContext _appIdentityDbContext;

        public UserRepo(AppIdentityDbContext appIdentityDbContext )
        {
            _appIdentityDbContext = appIdentityDbContext;
        }
        public async Task<int> RetrieveEmailWithOTP(int otp)
        {
            var ValidOTP = await _appIdentityDbContext.appUsers
                .Where(x => x.Otp == otp && x.OtpAge.HasValue && x.OtpAge!.Value.AddMinutes(10) > DateTime.Now)
                .Select(x => x.Otp)
                .FirstOrDefaultAsync();

            // Check if ValidOTP has no value
            if (!ValidOTP.HasValue)
            {
                return -1;
            }

            return ValidOTP.Value;
        }



        public async Task<int> SaveChangesAsync()
        {
            return await _appIdentityDbContext.SaveChangesAsync();
        }



    }
}
