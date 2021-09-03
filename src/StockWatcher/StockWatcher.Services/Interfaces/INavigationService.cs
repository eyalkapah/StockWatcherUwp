namespace StockWatcher.Services.Interfaces
{
    public interface INavigationService
    {
        void SetFrame(object frame);

        void NavigateToLogin();
        void NavigateToCreateAccount();
        void NavigateToMain();
        void NavigateBack();
        void SetInnerFrame(object contentFrame);
    }
}
