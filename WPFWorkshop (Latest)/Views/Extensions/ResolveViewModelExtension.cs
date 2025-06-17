using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Markup;

namespace WPFWorkshop.Views
{
    class ResolveViewModelExtension : MarkupExtension
    {
        public Type ViewModelType { get; set; }

        public ResolveViewModelExtension() { }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                return this;  // ≡ defer instantiation to runtime context

            IProvideValueTarget target = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            if (target?.TargetObject is not FrameworkElement frameworkElement)
                return this;

            IServiceScope scope = App.RootProvider.CreateScope();
            object viewModel = scope.ServiceProvider.GetRequiredService(ViewModelType);

            frameworkElement.Unloaded += (_,_) => scope.Dispose();
            return viewModel;
        }
    }
}