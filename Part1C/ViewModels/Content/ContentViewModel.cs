using Part1C.Commands;
using Part1C.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1C.ViewModels
{
    class ContentViewModel : IContentViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private object currentView = null;
        public object CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentView"));
            }
        }

        public RelayCommand ListCommand { get; private set; }

        public RelayCommand BoxCommand { get; private set; }

        public ContentViewModel()
        {
            ListCommand = new RelayCommand(OnListClicked);
            BoxCommand = new RelayCommand(OnBoxClicked);
        }

        private void OnListClicked(object parameter)
        {
            CurrentView = new EmployeeListView();
        }

        private void OnBoxClicked(object parameter)
        {
            CurrentView = new EmployeeBoxView();
        }
    }
}