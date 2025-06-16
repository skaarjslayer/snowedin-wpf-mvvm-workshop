using WPFWorkshop.Commands;

namespace WPFWorkshop.ViewModels
{
    class MockWorkspaceViewModel : IWorkspaceViewModel
    {
        #region Properties

        RelayCommand IWorkspaceViewModel.ListCommand => new RelayCommand((_) => { });
        RelayCommand IWorkspaceViewModel.BoxCommand => new RelayCommand((_) => { });
        RelayCommand IWorkspaceViewModel.AddCommand => new RelayCommand((_) => { });
        string IWorkspaceViewModel.CurrentName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IWorkspaceViewModel.CurrentRole { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IWorkspaceViewModel.CurrentDepartment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion Properties
    }
}