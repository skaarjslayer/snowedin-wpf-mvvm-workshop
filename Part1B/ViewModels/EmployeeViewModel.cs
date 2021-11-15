using Part1B.Commands;
using Part1B.Models;
using Part1B.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Part1B.ViewModels
{
    class EmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IReadOnlyCollection<EmployeeModel> employees;
        public IReadOnlyCollection<EmployeeModel> Employees
        {
            get { return employees; }
            private set
            {
                employees = value;
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Employees"));

            }
        }

        private string currentName = string.Empty;
        public string CurrentName { get { return currentName; } set { currentName = value; AddCommand.RaiseCanExecuteChanged(); } }

        private string currentDepartment = string.Empty;
        public string CurrentDepartment { get { return currentDepartment; } set { currentDepartment = value; AddCommand.RaiseCanExecuteChanged(); } }

        private string currentTitle = string.Empty;
        public string CurrentTitle { get { return currentTitle; } set { currentTitle = value; AddCommand.RaiseCanExecuteChanged(); } }

        public RelayCommand AddCommand { get; set; }

        public EmployeeViewModel()
        {
            AddCommand = new RelayCommand(OnAddClicked, CanAddBeClicked);

            ApplicationStateService.Instance.OnFileChanged += OnFileChanged;

            OnFileChanged(ApplicationStateService.Instance.CurrentFile);
        }

        ~EmployeeViewModel()
        {
            ApplicationStateService.Instance.OnFileChanged -= OnFileChanged;
        }

        private void OnFileChanged(IReadOnlyCollection<EmployeeModel> employees)
        {
            Employees = ApplicationStateService.Instance.CurrentFile;
        }

        private void OnAddClicked(object parameter)
        {
            ApplicationStateService.Instance.AddNewEmployee(new EmployeeModel(CurrentName, CurrentTitle, CurrentDepartment));
        }

        private bool CanAddBeClicked(object parameter)
        {
            return !string.IsNullOrEmpty(CurrentName) && !string.IsNullOrEmpty(CurrentDepartment) && !string.IsNullOrEmpty(CurrentTitle);
        }
    }
}