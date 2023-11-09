using BootRent.BL.Dtos.Boots;
using BootRent.DAL.Data.Models;
using BootRent.DAL.Repo.Boots;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public Guid Add(BootAddDto bootFromRequest)             //Add
        {
            Boot? boot = new Boot
            {

                IsAvailable = bootFromRequest.CheckInDate,
                BootId = bootFromRequest.BootId,
                Manufacturer = bootFromRequest.Manufacturer,
                BootName = bootFromRequest.BootName,
                ProductionYear = bootFromRequest.ProductionYear,
                CreatedAt = bootFromRequest.CreatedAt

            };
            _bootRepo.Add(boot);
            _bootRepo.SaveChanges();
            return boot.BootId;

        }

        public bool Delete(Guid id)                                     //Delete
        {
            Boot? boot = _bootRepo.GetBootById(id);
            if (boot == null)
            {
                return false;
            }
            _bootRepo.Delete(boot);

            _bootRepo.SaveChanges();
            return true;
        }

    public IEnumerable<BootReadDto> GetAllBoots()                   //GetAll
        {
        IEnumerable<Boot> bootsFromDb = _bootRepo.GetAllBoots();
        return bootsFromDb.Select(B => new BootReadDto
        {
            IsAvailable = B.IsAvailable,
            BootId =B.BootId,
            Manufacturer = B.Manufacturer,
            BootName = B.BootName,
            ProductionYear = B.ProductionYear,
            CreatedAt = B.CreatedAt
        });
        }

        public BootReadDto? GetBootById(Guid id)            //GetById
        {
        Boot? bootFromDb = _bootRepo.GetBootById(id);
            if (bootFromDb==null)
        {
            return null;
        }
        return new BootReadDto
        {
            IsAvailable = bootFromDb.IsAvailable,
            BootId = bootFromDb.BootId,
            Manufacturer = bootFromDb.Manufacturer,
            BootName = bootFromDb.BootName,
            ProductionYear = bootFromDb.ProductionYear,
            CreatedAt = bootFromDb.CreatedAt
        };
        }

        public bool Update(BootUpdateDto bootFromRequest)        //Update
        {
           Boot ? boot= _bootRepo.GetBootById(bootFromRequest.BootId);
            if (boot == null)
            {
                return false;
            }
            boot.BootName = bootFromRequest.BootName;
            boot.Manufacturer = bootFromRequest.Manufacturer;
            boot.ProductionYear = bootFromRequest.ProductionYear;
            boot.CreatedAt = bootFromRequest.CreatedAt;
            boot.IsAvailable = bootFromRequest.IsAvailable;
            _bootRepo.Update(boot);
            _bootRepo.SaveChanges();
            return true;
        }
    }
}
