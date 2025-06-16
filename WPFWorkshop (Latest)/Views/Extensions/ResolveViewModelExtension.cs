using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Markup;

namespace WPFWorkshop.Views.Extensions
{
    class ResolveViewModelExtension : MarkupExtension
    {
        public Type ViewModelType { get; }

        public ResolveViewModelExtension(Type viewModelType)
        {
            ViewModelType = viewModelType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            IProvideValueTarget target = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));

            if (target?.TargetObject is not FrameworkElement frameworkElement)
                return null;

            IServiceScope scope = App.RootProvider.CreateScope();
            object viewModel = scope.ServiceProvider.GetRequiredService(ViewModelType);

            frameworkElement.Unloaded += (_,_) => scope.Dispose();
            return viewModel;
        }
    }
}