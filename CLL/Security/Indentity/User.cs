using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLL.Security.Indentity
{
    public abstract class User
    {
        public int Id { get; }
        public string Name { get; }
        protected string UserType { get; }

        public User(int id, string name, string userType)
        {
            Id = id;
            Name = name;
            UserType = userType;
        }
    }
}
