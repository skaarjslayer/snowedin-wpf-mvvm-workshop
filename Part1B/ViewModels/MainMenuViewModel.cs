using Microsoft.Win32;
using Part1B.Commands;
using Part1B.Services;
using System.Diagnostics;
using System.Windows;

namespace Part1B.ViewModels
{
    class MainMenuViewModel
    {
        //public ExitCommand ExitCommand { get; private set; } = new ExitCommand();
        public RelayCommand NewCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand LoadCommand { get; private set; }
        public RelayCommand ExitCommand { get; private set; }

        public MainMenuViewModel()
        {
            NewCommand = new RelayCommand(OnNewClicked);
            SaveCommand = new RelayCommand(OnSaveClicked);
            LoadCommand = new RelayCommand(OnLoadClicked);
            ExitCommand = new RelayCommand(OnExitClicked);
        }

        private void OnNewClicked(object parameter)
        {
            EmployeeModelFileService.Instance.RequestCreateNewFile(EmployeeModelFileService.EmptyFile.ToArray());
        }

        private void OnSaveClicked(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog().Value)
            {
                EmployeeModelFileService.Instance.RequestSaveFile(saveFileDialog.FileName);
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
                EmployeeModelFileService.Instance.RequestLoadFile(openFileDialog.FileName);
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