using Microsoft.Win32;
using Part1B.Commands;
using Part1B.Services;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Part1B.ViewModels
{
    class MainMenuViewModel
    {
        public ICommand NewCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand LoadCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }

        public MainMenuViewModel()
        {
            NewCommand = new RelayCommand(OnNewClicked);
            SaveCommand = new RelayCommand(OnSaveClicked);
            LoadCommand = new RelayCommand(OnLoadClicked);
            ExitCommand = new RelayCommand(OnExitClicked);
        }

        private void OnNewClicked(object parameter)
        {
            ApplicationStateService.Instance.RequestCreateNewFile();
        }

        private void OnSaveClicked(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog().Value)
            {
                ApplicationStateService.Instance.RequestSaveFile(saveFileDialog.FileName);
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
                ApplicationStateService.Instance.RequestLoadFile(openFileDialog.FileName);
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
    }
}