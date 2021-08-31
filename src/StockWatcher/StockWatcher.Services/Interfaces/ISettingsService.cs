using StockWatcher.Models.Settings;

namespace StockWatcher.Services.Interfaces
{
    public interface ISettingsService
    {
        ApplicationSettings Settings { get; }
    }
}
