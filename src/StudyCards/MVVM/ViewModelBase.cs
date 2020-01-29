using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace StudyCards.MVVM
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private readonly SynchronizationContext synchronizationContext;

        protected ViewModelBase()
        {
            this.synchronizationContext = SynchronizationContext.Current;
        }

        protected bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = default)
        {
            this.synchronizationContext.Post(_ =>
                            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)), null);
        }
    }
}
