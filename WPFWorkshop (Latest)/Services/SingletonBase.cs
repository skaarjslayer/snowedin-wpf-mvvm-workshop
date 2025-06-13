using System;

namespace WPFWorkshop.Services
{
    abstract class SingletonBase<T>
    {
        #region Properties

        private static readonly Lazy<T> LazyInstance = new Lazy<T>(() => (T)Activator.CreateInstance(typeof(T), true));
        public static T Instance { get { return LazyInstance.Value; } }

        #endregion Properties
    }
}