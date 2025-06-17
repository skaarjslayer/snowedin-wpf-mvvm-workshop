using WPFWorkshop.Commands;
using WPFWorkshop.Data;

namespace WPFWorkshop.ViewModels
{
    class MockWorkspaceViewModel : IWorkspaceViewModel
    {
        #region Properties

        public WorkspaceFile WorkspaceFile { get; }
        public IWorkspaceViewModel.ViewMode CurrentViewMode => IWorkspaceViewModel.ViewMode.List;
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
            WorkspaceFile = new WorkspaceFile(new List<Employee>()
            {
                new Employee("Jimmy", "Technical Specialist", "Engineering"),
                new Employee("Quentin", "SD4", "Engineering"),
                new Employee("Sergiy", "SD3", "Engineering"),
                new Employee("William", "SD3", "Engineering"),
            });

            CurrentName = "Cameron";
            CurrentRole = "SD4";
            CurrentDepartment = "Engineering";
        }

        #endregion Constructors
    }
}