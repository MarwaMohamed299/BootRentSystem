using BootRent.BL.Dtos.Boots;
using BootRent.DAL.Repo.Boots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootRent.BL.Managers.Boos
{
   public class BootManager : IBootManager
    {
        private readonly IBootRepo _bootRepo;

        public BootManager(IBootRepo bootRepo)
        {
            _bootRepo = bootRepo;
         }

        public Guid Add(BootReadDto bootReadDto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BootReadDto> GetAllBoots()
        {
            throw new NotImplementedException();
        }

        public BootReadDto? GetBootById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(BootUpdateDto bootUpdateDtos)
        {
            throw new NotImplementedException();
        }
    }
}
