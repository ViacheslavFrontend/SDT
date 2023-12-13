using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Menu
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public bool IsAvailable { get; set; }

        public string Description { get; set; }
    }
}
