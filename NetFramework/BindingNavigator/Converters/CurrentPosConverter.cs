using System;
using System.Globalization;
using System.Windows.Data;

namespace BindingNavigator.Converters
{
    internal class CurrentPosConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                return (int)value + 1;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int? ret = null;
            if (value is string)
            {
                int tmp;
                if (Int32.TryParse((string)value, out tmp))
                {
                    ret = tmp - 1;
                }
            }
            return ret;
        }
    }
}