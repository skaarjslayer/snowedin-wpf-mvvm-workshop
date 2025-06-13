using WPFWorkshop.Commands;
using System;

namespace WPFWorkshop.ViewModels
{
    class MockContentViewModel : IContentViewModel
    {
        #region Properties

        RelayCommand IContentViewModel.ListCommand => throw new NotImplementedException();
        RelayCommand IContentViewModel.BoxCommand => throw new NotImplementedException();
        RelayCommand IContentViewModel.AddCommand => throw new NotImplementedException();
        string IContentViewModel.CurrentName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IContentViewModel.CurrentDepartment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IContentViewModel.CurrentTitle { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion Properties
    }
}