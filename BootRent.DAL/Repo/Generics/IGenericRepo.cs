using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootRent.DAL.Repo.Generics
{
    public interface IGenericRepo<T> where T :class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T>? GetById( Guid id);
        void Add(T item);
        void Update(T item);
        void Delete(T item);

    }
}
