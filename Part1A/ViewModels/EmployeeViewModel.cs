using Part1A.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Part1A.ViewModels
{
    class EmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IReadOnlyCollection<EmployeeModel> Employees { get; private set; }

        public EmployeeViewModel(params EmployeeModel[] employees)
        {
            Employees = employees.ToList().AsReadOnly();

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Employees"));
        }
    }
}