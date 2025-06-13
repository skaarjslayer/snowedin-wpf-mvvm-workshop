using System;
using System.Windows.Input;

namespace Part1C.ViewModels
{
    class MockMainMenuViewModel : IMainMenuViewModel
    {
        #region Properties

        public ICommand NewCommand => throw new NotImplementedException();
        public ICommand SaveCommand => throw new NotImplementedException();
        public ICommand LoadCommand => throw new NotImplementedException();
        public ICommand ExitCommand => throw new NotImplementedException();

        #endregion Properties
    }
}