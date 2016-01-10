namespace System.Infrastructure.Services
{
    public class VMOpenCloseEventArgs
    {
        public Type ViewModelType { get; private set; }

        public object DataContext { get; private set; }

        public string Region { get; private set; }

        public VMOpenCloseEventArgs(Type viewModelType, object dataContext, string region)
        {
            ViewModelType = viewModelType;
            DataContext = dataContext;
            Region = region;
        }
    }
}