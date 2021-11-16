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
    interface IEmployeeViewModel : INotifyPropertyChanged
    {
        IReadOnlyCollection<EmployeeModel> Employees { get; }
        string CurrentName { get; }
        string CurrentDepartment { get; }
        string CurrentTitle { get; }
        RelayCommand AddCommand { get; }
    }
}