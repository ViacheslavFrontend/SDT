using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DbSet<T> _set;
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public void Create(T entity)
        {
            _set.Add(entity);
        }

        public List<T> GetAll()
        {
            return _set.ToList();
        }
        public List<T> Find(Func<T, bool> predicate)
        {
            return _set.Where(predicate).ToList();
        }

        public T GetById(int id)
        {
            return _set.Find(id);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _set.Remove(entity);
        }
        public void Update(T entity)
        {
            _set.Update(entity);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
