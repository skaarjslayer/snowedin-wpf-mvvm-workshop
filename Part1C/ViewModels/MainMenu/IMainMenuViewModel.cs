using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Part1C.ViewModels
{
    interface IMainMenuViewModel
    {
        ICommand NewCommand { get; }
        ICommand SaveCommand { get; }
        ICommand LoadCommand { get; }
        ICommand ExitCommand { get; }
    }
}