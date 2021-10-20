using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1B.Models
{
    class EmployeeModel
    {
        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Department { get; private set; }

        public EmployeeModel(string name, string title, string department)
        {
            Name = name;
            Title = title;
            Department = department;
        }
    }
}