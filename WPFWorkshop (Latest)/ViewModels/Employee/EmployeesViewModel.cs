using WPFWorkshop.Data;
using WPFWorkshop.Services;
using System.ComponentModel;

namespace WPFWorkshop.ViewModels
{
    class EmployeesViewModel : IEmployeesViewModel, INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Properties

        private IReadOnlyCollection<Employee> employees;
        public IReadOnlyCollection<Employee> Employees
        {
            get { return employees; }
            private set
            {
                employees = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Employees)));
            }
        }

        #endregion Properties

        #region Constructors

        public EmployeesViewModel()
        {
            // PROBLEM - not unregistering
          //  ApplicationStateService.Instance.OnFileChanged += OnFileChanged;

          //  OnFileChanged(ApplicationStateService.Instance.CurrentFile);
        }

        #endregion Constructors

        #region Methods

        private void OnFileChanged(IReadOnlyCollection<Employee> employees)
        {
          //  Employees = ApplicationStateService.Instance.CurrentFile;
        }

        #endregion Methods
    }
}