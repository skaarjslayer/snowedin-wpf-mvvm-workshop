using Part1C.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Part1C.VML
{
    class ViewModelLocator
    {
        private DependencyObject dummy = new DependencyObject();

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

        public IEmployeeViewModel EmployeeViewModel
        {
            get
            {
                if (IsInDesignMode())
                {
                    return new MockEmployeeViewModel();
                }

                return new EmployeeListViewModel();
            }
        }

        private bool IsInDesignMode()
        {
            return DesignerProperties.GetIsInDesignMode(dummy);
        }
    }
}