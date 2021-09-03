using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using StockWatcher.Common.Exceptions;
using StockWatcher.Services.Interfaces;
using StockWatcher.ViewModels.ViewModels;

namespace StockWatcher.Services
{
    public class NavigationService : INavigationService
    {
        private Frame _frame;
        private Frame _innerFrame;

        /// <summary>
        ///     Holds pair of TViewModel, TView mapping
        /// </summary>
        private static readonly ConcurrentDictionary<Type, Type> ViewModelToViewMap = new();

        public Frame Frame => _frame ??= Window.Current.Content as Frame;

        public Task NavigateAsync<T>(object parameter)
        {
            return NavigateInternalAsync(typeof(T), parameter);
        }


        public void NavigateBack()
        {
            if (_innerFrame is not { CanGoBack: true })
            {
                if (_frame is { CanGoBack: true })
                    _frame.GoBack();
            }
            else
            {
                if (_innerFrame.CanGoBack)
                    _innerFrame.GoBack();
            }
        }

        public void SetInnerFrame(object contentFrame)
        {
            _innerFrame = contentFrame as Frame;
        }

        public static void Register<TViewModel, TView>()
        {
            ViewModelToViewMap.TryAdd(typeof(TViewModel), typeof(TView));
        }

        private async Task NavigateInternalAsync(Type viewModelType, object parameter = null)
        {
            var pageType = GetView(viewModelType);

            var viewModel = Ioc.Default.GetService(viewModelType);

            var frame = _innerFrame ?? Frame;

            if (frame.DataContext is NavigationAwareViewModel currentViewModel)
                await currentViewModel.OnNavigatedFrom();

            frame.DataContext = viewModel;

            frame.Navigate(pageType, parameter);

            if (viewModel is NavigationAwareViewModel newViewModel) await newViewModel.OnNavigatedTo(parameter);
        }

        private static Type GetView(Type viewModelType)
        {
            try
            {
                return ViewModelToViewMap[viewModelType];
            }
            catch (Exception e)
            {
                throw new ViewModelResolveException(viewModelType, e);
            }
        }
    }
}