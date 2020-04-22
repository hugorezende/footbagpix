using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbagPix.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetById(Int64 id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
