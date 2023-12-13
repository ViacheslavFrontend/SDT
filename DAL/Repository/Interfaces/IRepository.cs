using DAL.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        List<T> Find(Func<T, bool> predicate);
        void Delete(int id);
        void Update(T entity);
        void Save();
    }
}
