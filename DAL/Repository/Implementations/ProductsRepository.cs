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
    public class ProductsRepository : Repository<Product>, IProductsRepository
    {
        public ProductsRepository(DbContext db) : base(db)
        {
        }
    }
}
