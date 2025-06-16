using WPFWorkshop.Commands;

namespace WPFWorkshop.ViewModels
{
    interface IWorkspaceViewModel
    {
        #region Properties

        RelayCommand ListCommand { get; }
        RelayCommand BoxCommand { get; }
        RelayCommand AddCommand { get; }
        string CurrentName { get; set;  }
        string CurrentRole { get; set;  }
        string CurrentDepartment { get; set; }

        #endregion Properties
    }
}