using Part1C.Commands;
using Part1C.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1C.ViewModels
{
    class MockEmployeeViewModel : IEmployeeViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IReadOnlyCollection<EmployeeModel> Employees { get; private set; }

        public string CurrentName { get; set; }

        public string CurrentDepartment { get; set; }

        public string CurrentTitle { get; set; }

        public RelayCommand AddCommand { get; set; }

        public MockEmployeeViewModel()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>()
            {
                new EmployeeModel("Cameron", "Suspicious Trapezoid", "Scrample Detection"),
                new EmployeeModel("Eric", "Cutlery Inspector", "Canada Revenue Agency"),
                new EmployeeModel("Allissia", "TabbyCat", "Sector 8"),
                new EmployeeModel("Murilo", "Egg", "???"),
            };

            Employees = employees.AsReadOnly();
        }
    }
}