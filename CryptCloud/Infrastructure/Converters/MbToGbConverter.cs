using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace CryptCloud.Infrastructure.Converters
{
    public class MbToGbConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is null) 
                return value;

            return Math.Round((double)value / 1024, 2) ;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
