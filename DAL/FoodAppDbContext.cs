using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FoodAppDbContext : DbContext
    {
        public DbSet<Dish> dishes { get; set; }
        public DbSet<Menu> menus { get; set; }
        public DbSet<Product> products { get; set; }

        public FoodAppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
