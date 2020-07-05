using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace FinanceCore.ViewModel
{
    class RelayCommand<T> : ICommand
    {
        private Action<T> executeFn;
        private Func<T, bool> canExecuteFn;
        private bool canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<T> executeFn, Func<T, bool> canExecuteFn = null)
        {
            this.executeFn = executeFn;
            this.canExecuteFn = canExecuteFn;
            if (canExecuteFn == null)
                this.canExecuteFn = x => true;
            this.canExecute = true;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            var can = this.canExecuteFn((T)parameter);
            if (can != canExecute)
            {
                canExecute = can;
                RaiseCanExecuteChanged();
            }
            return can;
        }

        public void Execute(object parameter)
        {
            this.executeFn((T)parameter);
        }
    }
}
