using BootRent.DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootRent.BL.Managers.AppUsers
{
    public class UserManager :IUserManager
    {
        private readonly IUserRepo _userRepo;

        public UserManager(IUserRepo  userRepo)
        {
            _userRepo = userRepo;
        }
    }
}
