using BootRent.DAL.Data.Models;

namespace BootRent.DAL.Repo.Boots
{
    public interface IBootRepo
    {
        IEnumerable<Boot> GetAllBoots();
        Boot? GetBootById(Guid Id);
        void Add(Boot boot);
        void Update(Boot boot);
        void Delete(Boot boot);
        int SaveChanges();
    }
}
