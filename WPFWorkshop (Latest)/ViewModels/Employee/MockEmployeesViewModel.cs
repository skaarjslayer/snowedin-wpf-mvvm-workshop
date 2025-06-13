using WPFWorkshop.Data;
using System.Collections.Generic;

namespace WPFWorkshop.ViewModels
{
    class MockEmployeesViewModel : IEmployeesViewModel
    {
        #region Properties

        public IReadOnlyCollection<Employee> Employees => new List<Employee>()
            {
                new Employee("Cameron", "Suspicious Trapezoid Inspector", "Anomalous Materials"),
                new Employee("Jimmy", "Prisoner", "Jimmy Containment"),
                new Employee("Quentin", "Egg", "Egg"),
                new Employee("Sergiy", "<redacted>", "Section 31"),
                new Employee("William", "Find Quentin", "Egg Hunting"),
            };

        #endregion Properties
    }
}