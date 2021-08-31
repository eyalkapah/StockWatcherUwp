using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace StockWatcher.Converters
{
    public class GeneralToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string str)
            {
                return string.IsNullOrWhiteSpace(str)
                    ? Visibility.Collapsed
                    : Visibility.Visible;
            }

            if (value is bool b)
            {
                return b
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
