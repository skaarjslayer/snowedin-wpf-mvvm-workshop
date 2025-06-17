using System.ComponentModel;
using WPFWorkshop.Commands;
using WPFWorkshop.Data;
using WPFWorkshop.Services.Workspace;

namespace WPFWorkshop.ViewModels
{
    class WorkspaceViewModel : IDisposable, IWorkspaceViewModel, INotifyPropertyChanged
    {
        #region Enums

        public enum ViewMode { List, Box }

        #endregion Enumms

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Properties

        public WorkspaceFile WorkspaceFile => _workspaceService.CurrentFile;

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

        private string _currentRole = string.Empty;
        public string CurrentRole { get { return _currentRole; } set { _currentRole = value; AddCommand.RaiseCanExecuteChanged(); } }

        private string _currentDepartment = string.Empty;
        public string CurrentDepartment { get { return _currentDepartment; } set { _currentDepartment = value; AddCommand.RaiseCanExecuteChanged(); } }

        #endregion Properties

        #region Fields

        private IWorkspaceService _workspaceService;

        #endregion Fields

        #region Constructors

        public WorkspaceViewModel(IWorkspaceService workspaceService)
        {
            _workspaceService = workspaceService;
            _workspaceService.CurrentFileChanged += OnCurrentFileChanged;

            ListCommand = new RelayCommand(OnListClicked);
            BoxCommand = new RelayCommand(OnBoxClicked);
            AddCommand = new RelayCommand(OnAddClicked, CanAddBeClicked);
        }

        #endregion Constructors

        #region Methods

        public void Dispose()
        {
            _workspaceService.CurrentFileChanged -= OnCurrentFileChanged;
        }

        private void OnCurrentFileChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WorkspaceFile)));
        }

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
            _workspaceService.CurrentFile.AddEmployee(new Employee(CurrentName, CurrentRole, CurrentDepartment));
        }

        private bool CanAddBeClicked(object parameter)
        {
            return  !string.IsNullOrWhiteSpace(CurrentName) &&
                    !string.IsNullOrWhiteSpace(CurrentRole) &&
                    !string.IsNullOrWhiteSpace(CurrentDepartment);
        }

        #endregion Methods
    }
}