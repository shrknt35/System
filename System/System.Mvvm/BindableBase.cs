using System.Collections.Generic;
using System.Collections.Specialized;
using System.Common.Dialogs;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace System.Mvvm
{
    public abstract class BindableBase : IBindable
    {
        protected IVMLocator VMLocator { get; private set; }

        private readonly Dictionary<string, object> _propeties;

        public bool IsDisposed { get; private set; }

        public string Error
        {
            get { return GetValue<string>(); }
            protected set { SetValue(value); }
        }

        public string this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }

        public ICommand CloseCommand { get; }

        protected BindableBase()
        {
            _propeties = new Dictionary<string, object>();
            CloseCommand = new RelayCommand<DialogResult>(OnClose);
        }

        protected BindableBase(IVMLocator vmLocator)
            : this()
        {
            VMLocator = vmLocator;
        }

        ~BindableBase()
        {
            if (IsDisposed)
                return;

            Dispose();
        }

        protected virtual void OnClose(DialogResult dialogResult)
        {
            RaiseCloseEvent(this, dialogResult);
        }

        public virtual void Dispose()
        {
            IsDisposed = true;

            _propeties.Clear();

            GC.SuppressFinalize(this);
        }

        #region Protected Methods

        protected void SetValue(object value, [CallerMemberName] string propertyName = "")
        {
            // ReSharper disable once ExplicitCallerInfoArgument
            SetValue(value, null, propertyName);
        }

        protected void SetValue<TValueType>(TValueType value, Action<TValueType> propertyChangedCallback = null,
            [CallerMemberName] string propertyName = "")
        {
            if (_propeties.ContainsKey(propertyName))
            {
                if (_propeties[propertyName] == (object)value)
                    return;

                _propeties[propertyName] = value;

                // ReSharper disable once ExplicitCallerInfoArgument
                RaisePropertyChangedEvent(propertyName);

                if (propertyChangedCallback != null)
                    propertyChangedCallback(value);
            }
            else
            {
                _propeties.Add(propertyName, value);

                // ReSharper disable once ExplicitCallerInfoArgument
                RaisePropertyChangedEvent(propertyName);

                if (propertyChangedCallback != null)
                    propertyChangedCallback(value);
            }
        }

        protected TPropertyType GetValue<TPropertyType>([CallerMemberName] string propertyName = "")
        {
            if (_propeties.ContainsKey(propertyName))
                return (TPropertyType)_propeties[propertyName];

            return default(TPropertyType);
        }

        #endregion Protected Methods

        #region EVENTS

        public event ViewModelEventHandler Closed;

        protected virtual void RaiseCloseEvent(IBindable viewModel, DialogResult viewModelCloseResult)
        {
            var handler = Closed;
            if (handler != null)
                handler(viewModel, viewModelCloseResult);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChangedEvent([CallerMemberName] string propertyName = "")
        {
            var handle = PropertyChanged;
            if (handle != null)
                handle(this, new PropertyChangedEventArgs(propertyName));
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected virtual void RaiseCollectionChangedEvent(NotifyCollectionChangedEventArgs e)
        {
            var handler = CollectionChanged;
            if (handler != null)
                handler(this, e);
        }

        #endregion EVENTS
    }
}