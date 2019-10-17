using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BindingNavigator.Converters
{
    public class ConverterBoolCollapsed : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    bool boolValue = (bool)value;
                    if (boolValue)
                    {
                        return Visibility.Visible;
                    }

                    return Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }
}