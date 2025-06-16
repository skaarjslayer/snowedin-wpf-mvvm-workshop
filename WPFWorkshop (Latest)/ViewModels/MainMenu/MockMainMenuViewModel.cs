using System.Windows.Input;
using WPFWorkshop.Commands;

namespace WPFWorkshop.ViewModels
{
    class MockMainMenuViewModel : IMainMenuViewModel
    {
        #region Properties

        public ICommand NewCommand => new RelayCommand((_) => { });
        public ICommand SaveCommand => new RelayCommand((_) => { });
        public ICommand LoadCommand => new RelayCommand((_) => { });
        public ICommand ExitCommand => new RelayCommand((_) => { });

        #endregion Properties
    }
}