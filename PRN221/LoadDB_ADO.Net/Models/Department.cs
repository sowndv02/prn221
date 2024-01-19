using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDB_Exercise2.Models
{
    public class Department
    {
        public string Id {  get; set; }
        public string Name { get; set; }

        public Department(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public Department()
        {
        }
    }
}
