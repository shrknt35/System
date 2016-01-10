using System.Collections.Generic;

namespace System.Infrastructure
{
    public class IocContainer : IContainer
    {
        private readonly Dictionary<Type, object> _viewModelToViewInstanceMap;
        private readonly Dictionary<Type, Type> _viewModelToViewTypeMap;

        public IocContainer()
        {
            _viewModelToViewTypeMap = new Dictionary<Type, Type>();
            _viewModelToViewInstanceMap = new Dictionary<Type, object>();
        }

        public TInstanceType ResolveFor<TKeyType, TInstanceType>()
        {
            var keyType = typeof(TKeyType);
            return ResolveFor<TInstanceType>(keyType);
        }

        public TKeyType ResolveFor<TKeyType>(Type keyType)
        {
            var instance = (TKeyType)Activator.CreateInstance(_viewModelToViewTypeMap[keyType]);

            if (!_viewModelToViewInstanceMap.ContainsKey(keyType))
                AddRelation(keyType, instance);

            return instance;
        }

        public TInstanceType GetRelativeView<TInstanceType>(Type relativewType)
        {
            return (TInstanceType)_viewModelToViewInstanceMap[relativewType];
        }

        private void AddRelation(Type keyType, object instanceType)
        {
            _viewModelToViewInstanceMap.Add(keyType, instanceType);
        }

        public void RemoveRelativeView(Type type)
        {
            _viewModelToViewInstanceMap.Remove(type);
        }

        public void AddMapping<TKeyType, TValueType>()
        {
            AddMapping<TValueType>(typeof(TKeyType));
        }

        public void AddMapping<TValueType>(Type keyType)
        {
            AddMapping(keyType, typeof(TValueType));
        }

        public void AddMapping(Type keyType, Type valueType)
        {
            _viewModelToViewTypeMap.Add(keyType, valueType);
        }

        public void Clear()
        {
            _viewModelToViewInstanceMap.Clear();
            _viewModelToViewTypeMap.Clear();
        }
    }
}