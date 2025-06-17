using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;
using WPFWorkshop.Commands;
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

        private IWorkspaceService _workspaceService;

        #endregion Fields

        #region Constructors

        public MainMenuViewModel(IWorkspaceService workspaceService)
        {
            _workspaceService = workspaceService;

            NewCommand = new RelayCommand(OnNewClicked);
            SaveCommand = new RelayCommand(OnSaveClicked);
            LoadCommand = new RelayCommand(OnLoadClicked);
            ExitCommand = new RelayCommand(OnExitClicked);
        }

        #endregion Constructors

        #region Methods

        private void OnNewClicked(object parameter)
        {
            void NewFile()
            {
                _workspaceService.StartNewFile();
            }

            if (_workspaceService.IsCurrentFileDirty())
            {
                MessageBoxResult result = MessageBox.Show(
                    "Current file has unsaved changes. Are you sure you wish to start a new file?",
                    "Confirmation",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    NewFile();
                }
            }
            else
            {
                NewFile();
            }
        }

        private void OnSaveClicked(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog().Value)
            {
                _workspaceService.SaveCurrentFile(saveFileDialog.FileName);
            }
        }

        private void OnLoadClicked(object parameter)
        {
            void LoadFile()
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                if (openFileDialog.ShowDialog().Value)
                {
                    _workspaceService.LoadFile(openFileDialog.FileName);
                }
            }

            if (_workspaceService.IsCurrentFileDirty())
            {
                MessageBoxResult result = MessageBox.Show(
                    "Current file has unsaved changes. Are you sure you wish to load a new file?",
                    "Confirmation",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    LoadFile();
                }
            }
            else
            {
                LoadFile();
            }
        }

        private void OnExitClicked(object parameter)
        {
            void Shutdown()
            {
                Application.Current.Shutdown();
            }

            if(_workspaceService.IsCurrentFileDirty())
            {
                MessageBoxResult result = MessageBox.Show(
                    "Current file has unsaved changes. Are you sure you wish to quit?",
                    "Confirmation",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Shutdown();
                }
            }
            else
            {
                Shutdown();
            }
        }

        #endregion Methods
    }
}