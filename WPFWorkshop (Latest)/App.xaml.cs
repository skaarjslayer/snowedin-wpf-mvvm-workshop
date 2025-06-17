using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Windows;
using WPFWorkshop.Services.File;
using WPFWorkshop.Services.Serialization;
using WPFWorkshop.Services.Workspace;
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
            services.AddSingleton<ISerializationService, NewtonsoftJsonSerializationService>((_) => new(new()
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full
            }));
            services.AddSingleton<IPersistenceService, FilePersistenceService>();
            services.AddSingleton<IWorkspaceService, WorkspaceService>();
            services.AddScoped<IMainMenuViewModel, MainMenuViewModel>();
            services.AddScoped<IWorkspaceViewModel, WorkspaceViewModel>();

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