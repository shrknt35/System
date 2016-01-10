using System.Windows.Input;

namespace System.Mvvm
{
    public interface IRelayCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}