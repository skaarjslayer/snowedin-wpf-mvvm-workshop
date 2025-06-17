using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.ComponentModel;
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

        #endregion Properties

        #region Methods

        protected override void OnStartup(StartupEventArgs e)
        {
            _rootProvider = GetServiceProvider();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (_rootProvider is IDisposable disposable)
                disposable.Dispose();

            base.OnExit(e);
        }

        public static IServiceProvider GetServiceProvider()
        {
            if(_rootProvider is not null)
                return _rootProvider;

            if(IsInDesignMode())
            {
                ServiceCollection services = new();
                services.AddScoped<IMainMenuViewModel, MockMainMenuViewModel>();
                services.AddScoped<IWorkspaceViewModel, MockWorkspaceViewModel>();
                _rootProvider = services.BuildServiceProvider();
                return _rootProvider;
            }
            else
            {
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
                return _rootProvider;
            }
        }

        private static bool IsInDesignMode()
        {
            return DesignerProperties.GetIsInDesignMode(new DependencyObject());
        }

        #endregion Methods
    }
}