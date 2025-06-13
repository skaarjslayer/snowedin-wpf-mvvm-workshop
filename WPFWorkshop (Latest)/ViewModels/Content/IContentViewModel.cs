using Part1C.Commands;

namespace Part1C.ViewModels
{
    interface IContentViewModel
    {
        #region Properties

        RelayCommand ListCommand { get; }
        RelayCommand BoxCommand { get; }
        RelayCommand AddCommand { get; }
        string CurrentName { get; set;  }
        string CurrentDepartment { get; set; }
        string CurrentTitle { get; set;  }

        #endregion Properties
    }
}