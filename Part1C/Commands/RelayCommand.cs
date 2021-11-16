using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Part1C.Commands
{
    class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> executeMethod = null;
        private Predicate<object> canExecuteMethod = null;

        public RelayCommand(Action<object> executeMethod, Predicate<object> canExecuteMethod = null)
        {
            Debug.Assert(executeMethod != null, "executeMethod cannot be null.");

            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
        }

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
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}