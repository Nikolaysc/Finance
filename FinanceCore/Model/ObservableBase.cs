using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FinanceCore.Model
{
    public class ObservableBase : INotifyPropertyChanged, IDisposable
    {
        protected ObservableBase() { }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool Set<T>(ref T value, T newValue, [CallerMemberName] string propName = null)
        {
            if (!object.Equals(value, newValue))
            {
                value = newValue;
                RaisePropertyChanged(propName);
                return true;
            }
            return false;
        }

        protected void RaisePropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public virtual void Dispose()
        {
            
        }
    }
}
