using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using StockWatcher.Configurations;

namespace StockWatcher
{
    sealed partial class App : Application
    {
        public IConfiguration Configuration { get; set; }


        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }


        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            if (!(Window.Current.Content is Frame rootFrame))
            {
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                Window.Current.Content = rootFrame;

                BuildConfiguration();

                ConfigureServices();

                RegisterEvents();
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {

                    rootFrame.Navigate(typeof(ShellPage), e.Arguments);
                }

                Window.Current.Activate();
            }
        }

        private void RegisterEvents()
        {
        }

        private void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.ConfigureServices();

            services.ConfigureConditionalServices(Configuration);

            services.ConfigureViewModels();

            services.ConfigureApplicationSettings(Configuration);

            services.ConfigureDb(Configuration, "StockWatcher");

            var provider = services.BuildServiceProvider();

            Ioc.Default.ConfigureServices(provider);
        }

        private void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder();

#if DEBUG
            builder.AddJsonFile("appSettings-debug.json", false);
#else
            builder.AddJsonFile("appSettings.json", false);
#endif

            Configuration = builder.Build();
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
