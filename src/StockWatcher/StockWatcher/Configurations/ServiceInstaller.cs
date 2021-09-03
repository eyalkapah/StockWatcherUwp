using System.IO;
using Windows.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockWatcher.Models.Settings;
using StockWatcher.Services;
using StockWatcher.Services.Interfaces;
using StockWatcher.Services.Services;

namespace StockWatcher.Configurations
{
    public static class ServiceInstaller
    {
        private static readonly LogService LogService;

        static ServiceInstaller()
        {
            LogService = new LogService();
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            return services.AddSingleton<ITextService, TextService>()
                .AddSingleton<ILogService>(LogService)
                .AddSingleton<INavigationService, NavigationService>()
                .AddSingleton<IDbService, DbService>();
        }

        public static void ConfigureConditionalServices(this IServiceCollection services, IConfiguration configuration)
        {

        }

        public static void ConfigureDb(this IServiceCollection services, IConfiguration configuration, string name)
        {
            var connectionString = configuration.GetConnectionString(name);

            services.AddSingleton<IDbService>(_ => new DbService(connectionString));
        }

        public static void ConfigureApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.Get<ApplicationSettings>();

            services.AddSingleton<ISettingsService>(_ => new SettingsService(settings));
        }
    }
}
