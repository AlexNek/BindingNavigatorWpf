using System;
using System.Globalization;
using System.Windows.Data;

namespace BindingNavigator.Converters
{
    /// <summary>
    /// Class CurrentPosConverter.
    /// convert range 0..n-1 to 1..n and back
    /// Implements the <see cref="System.Windows.Data.IValueConverter" />
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    internal class CurrentPosConverter : IValueConverter
    {
        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>System.Object.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                return (int)value + 1;
            }
            return null;
        }

        /// <summary>
        /// Converts the back.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>System.Object.</returns>
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