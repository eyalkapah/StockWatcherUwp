using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;

namespace StockWatcher.ViewModels.ViewModels
{
    public partial class ShellViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _title;

        public ShellViewModel()
        {
            Title = "Main page";
        }

        [ICommand]
        private void ChangeTitle()
        {
            Title += " updated";
        }
    }
}
