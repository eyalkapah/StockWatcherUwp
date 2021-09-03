using System.Threading.Tasks;

namespace StockWatcher.Services.Interfaces
{
    public interface INavigationService
    {
        void NavigateBack();
        void SetInnerFrame(object contentFrame);

        Task NavigateAsync<T>(object parameter = null);
    }
}
