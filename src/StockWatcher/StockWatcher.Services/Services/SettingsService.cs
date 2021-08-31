using StockWatcher.Models.Settings;
using StockWatcher.Services.Interfaces;

namespace StockWatcher.Services.Services
{
    public class SettingsService : ISettingsService
    {
        public ApplicationSettings Settings { get; }

        public SettingsService(ApplicationSettings settings)
        {
            Settings = settings;
        }
    }
}
