using System;

namespace Part1C.Services
{
    abstract class SingletonBase<T>
    {
        private static readonly Lazy<T> LazyInstance = new Lazy<T>(() => (T)Activator.CreateInstance(typeof(T), true));

        public static T Instance { get { return LazyInstance.Value; } }
    }
}