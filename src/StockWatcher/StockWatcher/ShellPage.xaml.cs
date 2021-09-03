using Windows.UI.Xaml;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using StockWatcher.ViewModels.ViewModels;
using Windows.UI.Xaml.Controls;
using StockWatcher.Services.Interfaces;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StockWatcher
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShellPage : Page
    {
        public ShellViewModel Vm => DataContext as ShellViewModel;

        public ShellPage()
        {
            this.InitializeComponent();

            DataContext = Ioc.Default.GetService<ShellViewModel>();

            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var navigationService = Ioc.Default.GetService<INavigationService>();

            if (navigationService != null)
            {
                navigationService.SetInnerFrame(ContentFrame);

                navigationService.NavigateToLogin();
            }
        }
    }
}
