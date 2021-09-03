using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;

namespace StockWatcher.ViewModels.ViewModels
{
    public class NavigationAwareViewModel : ObservableObject
    {
        public virtual Task OnNavigatedTo(object parameter = null)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnNavigatedFrom()
        {
            return Task.CompletedTask;
        }
    }
}
