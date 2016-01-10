namespace System.Infrastructure.Services
{
    public class ShowDialogViewMessengerEventArgs : VMOpenCloseEventArgs
    {
        public Type ViewModelParentType { get; private set; }

        public ShowDialogViewMessengerEventArgs(Type viewModelType, Type viewModelParentType, object dataContext = null)
            : base(viewModelType, dataContext, string.Empty)
        {
            ViewModelParentType = viewModelParentType;
        }
    }
}