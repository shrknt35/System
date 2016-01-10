namespace System.Mvvm
{
    public interface IVMLocator
    {
        TViewModel GetViewModel<TViewModel>();

        IVMLocator RegisterType<TKey, TValue>() where TValue : TKey;

        IVMLocator RegisterInstance<TKey>(TKey instance);
    }
}