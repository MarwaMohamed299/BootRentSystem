using BootRent.BL.Dtos.Boots;
using BootRent.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootRent.BL.Managers.Boos
{
    public interface IBootManager
    {
        IEnumerable<BootReadDto> GetAllBoots();
        BootReadDto? GetBootById(Guid id);
        System.Guid Add(BootReadDto bootReadDto);
        bool Update(BootUpdateDto bootUpdateDtos);
        bool Delete(Guid id);

    }
}
