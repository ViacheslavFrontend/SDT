using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLL.Security.Indentity
{
    public class Acountant : User
    {
        public Acountant(int id, string name) : base(id, name, nameof(Acountant))
        {
        }
    }
}
