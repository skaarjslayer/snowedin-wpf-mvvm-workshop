using Part1C.Data;
using System.Collections.Generic;

namespace Part1C.ViewModels
{
    interface IEmployeesViewModel
    {
        #region Properties

        IReadOnlyCollection<Employee> Employees { get; }

        #endregion Properties
    }
}