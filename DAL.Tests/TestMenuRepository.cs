using DAL.Repository.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Tests
{
    internal class TestMenuRepository : MenusRepository
    {
        public TestMenuRepository(DbContext db) : base(db)
        {
        }
    }
}
