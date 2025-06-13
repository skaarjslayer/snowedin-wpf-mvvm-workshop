using System.Windows.Input;

namespace Part1C.ViewModels
{
    interface IMainMenuViewModel
    {
        #region Properties

        ICommand NewCommand { get; }
        ICommand SaveCommand { get; }
        ICommand LoadCommand { get; }
        ICommand ExitCommand { get; }

        #endregion Properties
    }
}