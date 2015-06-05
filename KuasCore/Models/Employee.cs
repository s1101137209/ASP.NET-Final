using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Models
{
    public class Employee
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Age { get; set; }

        public override string ToString()
        {
            return "Employee: Id = " + Id + ", Name = " + Name + ".";
        }
    }
}
