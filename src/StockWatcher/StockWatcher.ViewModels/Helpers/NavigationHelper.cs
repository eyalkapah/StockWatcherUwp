using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using StockWatcher.Services.Interfaces;
using StockWatcher.ViewModels.ViewModels;

namespace StockWatcher.ViewModels.Helpers
{
    public class NavigationHelper
    {
        public static Task NavigateToDefaultPageAsync()
        {
            var navigationService = Ioc.Default.GetService<INavigationService>();

            Debug.Assert(navigationService != null, "Failed to resolve navigation service");
            
            // if not authenticate
            return navigationService.NavigateAsync<LoginViewModel>();


        }
    }
}
