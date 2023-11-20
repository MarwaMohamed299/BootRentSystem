using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BootRent.DAL.Response
{
    public class UserManagerResponse
    {
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
    }
}
