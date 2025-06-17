using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Markup;

namespace WPFWorkshop.Views
{
    class ViewModelResolverExtension : MarkupExtension
    {
        public required Type ViewModelType { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            IProvideValueTarget target = serviceProvider.GetService<IProvideValueTarget>();
            if (target?.TargetObject is not FrameworkElement frameworkElement)
                return this;

            IServiceScope scope = App.GetServiceProvider().CreateScope();
            object viewModel = scope.ServiceProvider.GetRequiredService(ViewModelType);

            frameworkElement.Unloaded += (_, _) => scope.Dispose();
            return viewModel;
        }
    }
}