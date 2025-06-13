using System;
using System.Windows.Input;

namespace Part1C.Commands
{
    class RelayCommand : ICommand
    {
        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion Events

        #region Fields

        private Action<object> executeMethod = null;
        private Predicate<object> canExecuteMethod = null;

        #endregion Fields

        #region Constructors

        public RelayCommand(Action<object> executeMethod, Predicate<object> canExecuteMethod = null)
        {
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
        }

        #endregion Constructors

        #region Methods

        public bool CanExecute(object parameter)
        {
            return canExecuteMethod != null ? canExecuteMethod(parameter) : true;
        }

        public void Execute(object parameter)
        {
            executeMethod.Invoke(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion Methods
    }
}