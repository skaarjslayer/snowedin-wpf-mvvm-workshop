using WPFWorkshop.Data;
using System.Collections.Generic;

namespace WPFWorkshop.ViewModels
{
    interface IEmployeesViewModel
    {
        #region Properties

        IReadOnlyCollection<Employee> Employees { get; }

        #endregion Properties
    }
}