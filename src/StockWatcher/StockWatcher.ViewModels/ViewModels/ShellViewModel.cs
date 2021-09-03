using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;
using StockWatcher.Services.Interfaces;

namespace StockWatcher.ViewModels.ViewModels
{
    public partial class ShellViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private string _title;

        public ShellViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "Main page";
        }

        [ICommand]
        private void ChangeTitle()
        {
            Title += " updated";
        }

        [ICommand]
        public void Next()
        {
            //_navigationService.NavigateNext();
        }

        [ICommand]
        public void Back()
        {
            _navigationService.NavigateBack();
        }
    }
}
