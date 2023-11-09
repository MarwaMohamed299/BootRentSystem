using BootRent.DAL.Data.Models;
using BootRent.DAL.Repo.Generics;
using BootRent.DAL.UnitOfWork;

namespace BootRent.DAL.Repo.Boots
{
    public interface IBootRepo : IGenericRepo<Boot>
    {
        IEnumerable<Boot> GetAllBoots();
        Boot? GetBootById(Guid id);
        void Add(Boot boot);
        void Update(Boot boot);
        void Delete(Boot boot);
        int SaveChanges();
    }
}
