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
    class MockContentViewModel : IContentViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public object CurrentView { get { return new EmployeeListView(); } }

        public RelayCommand ListCommand => throw new NotImplementedException();

        public RelayCommand BoxCommand => throw new NotImplementedException();
    }
}