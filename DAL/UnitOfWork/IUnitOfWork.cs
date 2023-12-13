using DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDishesRepository dishesRepository { get; }
        IMenusRepository menusRepository { get; }
        void Save();
    }
}
