using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace StudyCards.MVVM
{
    public class ActionCommand : ICommand
    {
        private readonly Action action;
        private readonly Func<bool> canExecute;

        public ActionCommand(Action action, Func<bool>? canExecute = null)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null ? true : this.canExecute();
        }

        public void Execute(object parameter)
        {
            this.action();
        }
    }

    public class ActionCommand<T> : ICommand
    {
        private readonly Action<T> action;
        private readonly Func<T, bool> canExecute;

        public ActionCommand(Action<T> action, Func<T, bool> canExecute = null)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null ? true : this.canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            this.action((T)parameter);
        }
    }
}
