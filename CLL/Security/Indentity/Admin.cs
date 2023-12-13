using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLL.Security.Indentity
{
    public class Admin : User
    {
        public Admin(int id, string name) : base(id, name, nameof(Admin))
        {
        }
    }
}
