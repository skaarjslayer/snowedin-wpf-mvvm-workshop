using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace WPFWorkshop.Data
{
    class WorkspaceFile
    {
        #region Classes

        private class EqualityComparer : IEqualityComparer<WorkspaceFile>
        {
            #region Methods

            public bool Equals(WorkspaceFile x, WorkspaceFile y)
            {
                return x._employees.SequenceEqual(y._employees);
            }

            public int GetHashCode([DisallowNull] WorkspaceFile obj)
            {
                int hash = 17;

                foreach (Employee employee in obj.Employees)
                {
                    hash = hash * 31 + employee.GetHashCode();
                }

                return hash;
            }

            #endregion Methods
        }

        #endregion Classes

        #region Properties

        public static IEqualityComparer<WorkspaceFile> Comparer { get; } = new EqualityComparer();

        private ObservableCollection<Employee> _employees = new();
        public ICollection<Employee> Employees => _employees;

        #endregion Properties

        #region Constructors

        public WorkspaceFile()
        {

        }

        public WorkspaceFile(WorkspaceFile otherFile)
        {
            _employees = new(otherFile._employees);
        }

        #endregion Constructors

        #region Methods

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        #endregion Methods
    }
}