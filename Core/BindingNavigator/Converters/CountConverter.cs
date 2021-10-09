using System;
using System.Globalization;
using System.Windows.Data;

namespace BindingNavigator.NetCore.Converters
{
    /// <summary>
    /// Class CountConverter.
    /// Convert count to the specific text
    /// Implements the <see cref="System.Windows.Data.IValueConverter" />
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    internal class CountConverter : IValueConverter
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
                return string.Format("of {0}", value);
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
            return null;
        }
    }
}