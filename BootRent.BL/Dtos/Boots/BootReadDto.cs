using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootRent.BL.Dtos.Boots
{
    public class BootReadDto
    {
        public Guid BootId { get; set; }

      
        public string BootName { get; set; } = string.Empty;

        public string Manufacturer { get; set; } = string.Empty;

        public int ProductionYear { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
