using System;
using StockWatcher.Services.Interfaces;
using Windows.UI.Xaml.Controls;
using StockWatcher.Pages;

namespace StockWatcher.Services
{
    public class NavigationService : INavigationService
    {
        private Frame _frame;
        private Frame _contentFrame;

        public void SetFrame(object frame)
        {
            _frame = frame as Frame;
        }

        public void NavigateToLogin()
        {
            var loginPage = new LoginPage();

            Navigate(loginPage);
        }

        public void NavigateToCreateAccount()
        {
            //var createAccountPage = new CreateAccountPage();

            //Navigate(createAccountPage);
        }

        public void NavigateToMain()
        {
            var mainPage = new MainPage();

            Navigate(mainPage);
        }


        public void NavigateBack()
        {
            if (_contentFrame is not { CanGoBack: true }) 
            {
                if (_frame is { CanGoBack: true })
                    _frame.GoBack();
            }
            else
            {
                if (_contentFrame.CanGoBack)
                    _contentFrame.GoBack();
            }
        }

        public void SetInnerFrame(object contentFrame)
        {
            _contentFrame = contentFrame as Frame;
        }

        private void Navigate(Page page)
        {
            if (_frame == null)
                return;

            if (_frame.Navigate(page.GetType()))
            {

            }
        }
    }
}
