using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using StockWatcher.Configurations;
using StockWatcher.ViewModels.Helpers;
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace StockWatcher
{
    sealed partial class App : Application
    {
        public IConfiguration Configuration { get; set; }


        public App()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.PreferredLaunchViewSize = new Size(1280, 840);

            Configuration = BuildConfiguration();

            var services = new ServiceCollection();

            ConfigureServices(services);


            this.Suspending += OnSuspending;
        }


        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            if (Window.Current.Content is not Frame rootFrame)
            {
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                Window.Current.Content = rootFrame;

                RegisterEvents();
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    await NavigationHelper.NavigateToDefaultPageAsync();
                    //rootFrame.Navigate(typeof(ShellPage), e.Arguments);
                }

                Window.Current.Activate();
            }
        }

        private void RegisterEvents()
        {
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureServices();

            services.ConfigureConditionalServices(Configuration);

            services.ConfigureViewModels();

            services.ConfigureApplicationSettings(Configuration);
            
            services.ConfigureDb(Configuration, "StockWatcher");

            var provider = services.BuildServiceProvider();

            Ioc.Default.ConfigureServices(provider);
        }

     
        private static IConfiguration BuildConfiguration()
        {
            var builder = new ConfigurationBuilder();

#if DEBUG
            builder.AddJsonFile("appSettings-debug.json", false);
#else
            builder.AddJsonFile("appSettings.json", false);
#endif

            return builder.Build();
        }



        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }


        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
