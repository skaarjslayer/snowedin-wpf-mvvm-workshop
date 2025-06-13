using Part1C.Commands;
using Part1C.Data;
using Part1C.Services;
using System.ComponentModel;

namespace Part1C.ViewModels
{
    class ContentViewModel : IContentViewModel, INotifyPropertyChanged
    {
        #region Enums

        public enum ViewMode { List, Box }

        #endregion Enumms

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Properties

        public EmployeesViewModel Employee { get; } = new EmployeesViewModel();

        private ViewMode _viewMode;
        public ViewMode CurrentViewMode
        {
            get => _viewMode;
            set { _viewMode = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentViewMode))); }
        }

        public RelayCommand ListCommand { get; private set; }

        public RelayCommand BoxCommand { get; private set; }

        public RelayCommand AddCommand { get; private set; }

        private string _currentName = string.Empty;
        public string CurrentName { get { return _currentName; } set { _currentName = value; AddCommand.RaiseCanExecuteChanged(); } }

        private string _currentDepartment = string.Empty;
        public string CurrentDepartment { get { return _currentDepartment; } set { _currentDepartment = value; AddCommand.RaiseCanExecuteChanged(); } }

        private string _currentTitle = string.Empty;
        public string CurrentTitle { get { return _currentTitle; } set { _currentTitle = value; AddCommand.RaiseCanExecuteChanged(); } }

        #endregion Properties

        #region Constructors

        public ContentViewModel()
        {
            ListCommand = new RelayCommand(OnListClicked);
            BoxCommand = new RelayCommand(OnBoxClicked);
            AddCommand = new RelayCommand(OnAddClicked, CanAddBeClicked);
        }

        #endregion Constructors

        #region Methods

        private void OnListClicked(object parameter)
        {
            CurrentViewMode = ViewMode.List;
        }

        private void OnBoxClicked(object parameter)
        {
            CurrentViewMode = ViewMode.Box;
        }

        private void OnAddClicked(object parameter)
        {
            ApplicationStateService.Instance.AddNewEmployee(new Employee(CurrentName, CurrentTitle, CurrentDepartment));
        }

        private bool CanAddBeClicked(object parameter)
        {
            return  !string.IsNullOrEmpty(CurrentName) &&
                    !string.IsNullOrEmpty(CurrentDepartment) &&
                    !string.IsNullOrEmpty(CurrentTitle);
        }

        #endregion Methods
    }
}