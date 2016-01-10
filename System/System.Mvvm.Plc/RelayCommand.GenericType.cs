using System.Windows.Input;

namespace System.Mvvm
{
    public sealed class RelayCommand<TCommandParameter> : ICommand
    {
        private readonly Predicate<TCommandParameter> _canExecute;
        private readonly Action<TCommandParameter> _execute;

        public RelayCommand(Action<TCommandParameter> execute, Predicate<TCommandParameter> canExecute = null)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _canExecute = canExecute;
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return parameter != null && (_canExecute == null || _canExecute((TCommandParameter)parameter));
        }

        public void Execute(object parameter)
        {
            if (parameter != null) _execute((TCommandParameter)parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}