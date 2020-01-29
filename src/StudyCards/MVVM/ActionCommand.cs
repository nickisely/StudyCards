using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace StudyCards.MVVM
{
    public class ActionCommand : ICommand
    {
        private readonly Action action;
        private readonly Func<bool>? canExecute;

        public ActionCommand(Action action, Func<bool>? canExecute = null)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

#pragma warning disable CS0067
        public event EventHandler? CanExecuteChanged;
#pragma warning restore CS0067

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute();
        }

        public void Execute(object parameter)
        {
            this.action();
        }
    }

    public class ActionCommand<T> : ICommand
    {
        private readonly Action<T> action;
        private readonly Func<T, bool>? canExecute;

        public ActionCommand(Action<T> action, Func<T, bool>? canExecute = null)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

#pragma warning disable CS0067
        public event EventHandler? CanExecuteChanged;
#pragma warning restore CS0067

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            this.action((T)parameter);
        }
    }
}
