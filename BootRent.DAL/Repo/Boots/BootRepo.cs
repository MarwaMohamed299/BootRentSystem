using BootRent.DAL.Context.Rent;
using BootRent.DAL.Data.Models;

namespace BootRent.DAL.Repo.Boots
{
    public class BootRepo : IBootRepo
    {
        private readonly RentContext _rentContext;

        public BootRepo(RentContext rentContext)
        {
            _rentContext = rentContext;

        }
       



        public void Add(Boot boot)
        {
            throw new NotImplementedException();
        }

        public void Delete(Boot boot)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Boot> GetAllBoots()
        {
            throw new NotImplementedException();
        }

        public Boot? GetBootById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Boot boot)
        {
            throw new NotImplementedException();
        }
    }
}
