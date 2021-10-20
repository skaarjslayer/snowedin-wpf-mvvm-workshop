using Part1A.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Part1A.ViewModels
{
    class EmployeeViewModel
    {
        public IReadOnlyCollection<EmployeeModel> Employees { get; private set; }

        public EmployeeViewModel(params EmployeeModel[] employees)
        {
            Employees = employees.ToList().AsReadOnly();
        }
    }
}