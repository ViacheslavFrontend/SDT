using DAL.Repository.Implementations;
using DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private FoodAppDbContext _db;
        private IMenusRepository _menusRepository;
        private IDishesRepository _dishesRepository;

        public IDishesRepository dishesRepository { 
            get
            {
                if(_dishesRepository == null)
                {
                    _dishesRepository = new DishesRepository(_db);
                }
                return _dishesRepository; 
            }
        }

        public IMenusRepository menusRepository
        {
            get
            {
                if (_menusRepository == null)
                {
                    _menusRepository = new MenusRepository(_db);
                }
                return _menusRepository;
            }
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                     _db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
