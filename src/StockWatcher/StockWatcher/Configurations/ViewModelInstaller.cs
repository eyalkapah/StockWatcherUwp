using Microsoft.Extensions.DependencyInjection;
using StockWatcher.Pages;
using StockWatcher.Services;
using StockWatcher.ViewModels.ViewModels;

namespace StockWatcher.Configurations
{
    public static class ViewModelsInstaller
    {
        private static IServiceCollection _services;

        public static void ConfigureViewModels(this IServiceCollection services)
        {
            _services = services;

            RegisterView<ShellViewModel, ShellPage>();
            RegisterView<MainViewModel, MainPage>();
            RegisterView<LoginViewModel, LoginPage>();
        }

        private static void RegisterView<TViewModel, TView>()
        {
            _services.AddTransient(typeof(TViewModel));

            NavigationService.Register<TViewModel, TView>();
        }
    }
}
