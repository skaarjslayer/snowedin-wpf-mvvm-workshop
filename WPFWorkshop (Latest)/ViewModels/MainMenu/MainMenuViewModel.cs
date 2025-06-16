using Microsoft.Win32;
using WPFWorkshop.Commands;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using WPFWorkshop.Services.File;
using WPFWorkshop.Services.Workspace;

namespace WPFWorkshop.ViewModels
{
    class MainMenuViewModel : IMainMenuViewModel
    {
        #region Properties

        public ICommand NewCommand { get; init; }
        public ICommand SaveCommand { get; init; }
        public ICommand LoadCommand { get; init; }
        public ICommand ExitCommand { get; init; }

        #endregion Properties

        #region Fields

        private IPersistenceService _persistenceService;

        #endregion Fields

        #region Constructors

        public MainMenuViewModel(IPersistenceService persistenceService)
        {
            _persistenceService = persistenceService;

            NewCommand = new RelayCommand(OnNewClicked);
            SaveCommand = new RelayCommand(OnSaveClicked);
            LoadCommand = new RelayCommand(OnLoadClicked);
            ExitCommand = new RelayCommand(OnExitClicked);
        }

        #endregion Constructors

        #region Methods

        private void OnNewClicked(object parameter)
        {
            WorkspaceService.Instance.RequestCreateNewFile();
        }

        private void OnSaveClicked(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog().Value)
            {
                // singletons bad
                _persistenceService.dowhatever
               // ApplicationStateService.Instance.RequestSaveFile(saveFileDialog.FileName);
            }
            else
            {
                Debug.WriteLine("Save was cancelled.");
            }
        }

        private void OnLoadClicked(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog().Value)
            {
                WorkspaceService.Instance.RequestLoadFile(openFileDialog.FileName);
            }
            else
            {
                Debug.WriteLine("Load was cancelled.");
            }
        }

        private void OnExitClicked(object parameter)
        {
            Application.Current.Shutdown();
        }

        #endregion Methods
    }
}