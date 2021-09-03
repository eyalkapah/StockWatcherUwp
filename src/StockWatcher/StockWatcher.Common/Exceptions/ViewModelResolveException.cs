using System;

namespace StockWatcher.Common.Exceptions
{
    public class ViewModelResolveException : Exception
    {
        public ViewModelResolveException(Type viewModelType, Exception ex) : base(
            $"Failed to resolve a view for the view model: {viewModelType}", ex)
        {

        }
    }
}
