using Part1C.Commands;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Part1C.ViewModels
{
    class MockMainMenuViewModel : IMainMenuViewModel
    {
        public ICommand NewCommand => throw new NotImplementedException();
        public ICommand SaveCommand => throw new NotImplementedException();
        public ICommand LoadCommand => throw new NotImplementedException();
        public ICommand ExitCommand => throw new NotImplementedException();
    }
}