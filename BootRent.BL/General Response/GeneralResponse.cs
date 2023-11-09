using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootRent.BL.General_Response
{
    public class GeneralResponse
    {
        public string Message { set; get; } = string.Empty;

        public GeneralResponse(string message)
        {
            Message = message;
        }
    }
}
