using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLL.Security.Indentity
{
    public class Accountant : User
    {
        public Accountant(int id, string name) : base(id, name, nameof(Accountant))
        {
        }
    }
}
