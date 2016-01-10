using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;

namespace System.Mvvm
{
    public interface IBindable : INotifyPropertyChanged, IDataErrorInfo, INotifyCollectionChanged, IDisposable
    {
        bool IsDisposed { get; }

        ICommand CloseCommand { get; }

        event ViewModelEventHandler Closed;
    }
}