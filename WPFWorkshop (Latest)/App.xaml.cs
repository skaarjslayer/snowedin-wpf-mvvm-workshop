using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WPFWorkshop.Services.File;
using WPFWorkshop.Services.Serialization;
using WPFWorkshop.ViewModels;

namespace WPFWorkshop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Properties

        private static IServiceProvider _rootProvider;
        public static IServiceProvider RootProvider => _rootProvider;

        #endregion Properties

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ServiceCollection services = new();
            services.AddSingleton<ISerializationService, NewtonsoftJsonSerializationService>();
            services.AddSingleton<IPersistenceService, FilePersistenceService>();
            services.AddScoped<IMainMenuViewModel, MainMenuViewModel>();

            _rootProvider = services.BuildServiceProvider();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (_rootProvider is IDisposable disposable)
                disposable.Dispose();

            base.OnExit(e);
        }
    }
}