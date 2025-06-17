using WPFWorkshop.Commands;
using WPFWorkshop.Data;

namespace WPFWorkshop.ViewModels
{
    interface IWorkspaceViewModel
    {
        #region Enums

        public enum ViewMode { List, Box }

        #endregion Enumms

        #region Properties

        WorkspaceFile WorkspaceFile { get; }
        ViewMode CurrentViewMode { get; }
        RelayCommand ListCommand { get; }
        RelayCommand BoxCommand { get; }
        RelayCommand AddCommand { get; }
        string CurrentName { get; set;  }
        string CurrentRole { get; set;  }
        string CurrentDepartment { get; set; }

        #endregion Properties
    }
}