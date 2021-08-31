using System;
using System.Diagnostics;
using System.Net.Mime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace StockWatcher.Converters
{
    public class StringToResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if (value == null)
                    return null;

                var str = value.ToString();

                return Application.Current.Resources[str];
            }
            catch (Exception e)
            {
                Debug.Assert(false, "Couldn't find resource");

                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
