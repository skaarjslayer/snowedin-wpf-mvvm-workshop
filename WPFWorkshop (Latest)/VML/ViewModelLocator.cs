using WPFWorkshop.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace WPFWorkshop.VML
{
    class ViewModelLocator
    {
        #region Fields

        private DependencyObject dummy = new DependencyObject();

        #endregion Fields

        #region Methods

        public IMainMenuViewModel MainMenuViewModel
        {
            get
            {
                if (IsInDesignMode())
                {
                    return new MockMainMenuViewModel();
                }

                return new MainMenuViewModel();
            }
        }

        public IEmployeesViewModel EmployeeViewModel
        {
            get
            {
                if (IsInDesignMode())
                {
                    return new MockEmployeesViewModel();
                }

                return new EmployeesViewModel();
            }
        }

        public IContentViewModel ContentViewModel
        {
            get
            {
                if (IsInDesignMode())
                {
                    return new MockContentViewModel();
                }

                return new ContentViewModel();
            }
        }

        private bool IsInDesignMode()
        {
            return DesignerProperties.GetIsInDesignMode(dummy);
        }

        #endregion Methods
    }
}