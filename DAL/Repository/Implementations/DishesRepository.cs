using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Implementations
{
    public class DishesRepository : BaseRepository<Dish>, IDishesRepository
    {
        public DishesRepository(DbContext db) : base(db)
        {
        }
    }
}
