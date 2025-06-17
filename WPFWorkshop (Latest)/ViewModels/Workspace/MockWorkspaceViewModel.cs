using WPFWorkshop.Commands;

namespace WPFWorkshop.ViewModels
{
    class MockWorkspaceViewModel : IWorkspaceViewModel
    {
        #region Properties

        public RelayCommand ListCommand => new RelayCommand((_) => { });
        public RelayCommand BoxCommand => new RelayCommand((_) => { });
        public RelayCommand AddCommand => new RelayCommand((_) => { });
        public string CurrentName { get; set; }
        public string CurrentRole { get; set; }
        public string CurrentDepartment { get; set; }

        #endregion Properties

        #region Constructors

        public MockWorkspaceViewModel()
        {
            CurrentName = CurrentRole = CurrentDepartment = "ExampleInput";
        }

        #endregion Constructors
    }
}