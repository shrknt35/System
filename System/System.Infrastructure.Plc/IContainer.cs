namespace System.Infrastructure
{
    public interface IContainer
    {
        TInstanceType ResolveFor<TKeyType, TInstanceType>();

        TKeyType ResolveFor<TKeyType>(Type keyType);

        TInstanceType GetRelativeView<TInstanceType>(Type relativewType);

        void RemoveRelativeView(Type type);

        void AddMapping<TKeyType, TValueType>();

        void AddMapping<TValueType>(Type keyType);

        void AddMapping(Type keyType, Type valueType);

        void Clear();
    }
}