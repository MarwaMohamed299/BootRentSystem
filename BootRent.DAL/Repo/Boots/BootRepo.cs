using BootRent.DAL.Data.Context.Rent;
using BootRent.DAL.Data.Models;
using BootRent.DAL.Repo.Generics;

namespace BootRent.DAL.Repo.Boots
{
    public class BootRepo : GenericRepo<Boot>, IBootRepo
    {
        private readonly RentContext _rentContext;
        public BootRepo(RentContext rentContext) :base (rentContext)
        {
            _rentContext = rentContext;
        }


        public void Add(Boot boot)
        {
             _rentContext.Set<Boot>().Add(boot);
        }

        public void Delete(Boot boots)
        {
            _rentContext.Set<Boot>().Remove(boots);
        }

        public IEnumerable<Boot> GetAllBoots()
        {
            return _rentContext.Set<Boot>().ToList();

        }

        public Boot? GetBootById(Guid id)
        {
            return _rentContext.Set<Boot>().Find(id);

        }

        public int SaveChanges()
        {
            return _rentContext.SaveChanges();

        }

        public void Update(Boot boot)
        {
        }
    }
}
