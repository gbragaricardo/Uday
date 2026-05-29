using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace UDayCore.Converters
{
    public class EnumToColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null) return Colors.Gray;

            string enumType = value.GetType().Name;
            string enumValue = value.ToString();
            string suffix = parameter?.ToString() ?? "Bg";

            string resourceKey = $"{enumType}_{enumValue}_{suffix}";

            // Handle Dark Mode suffix
            if (Application.Current != null && Application.Current.RequestedTheme == AppTheme.Dark)
            {
                string darkResourceKey = $"{resourceKey}_Dark";
                if (Application.Current.Resources.TryGetValue(darkResourceKey, out var darkColorValue) &&
                    darkColorValue is Color darkColor)
                {
                    return darkColor;
                }
            }

            if (Application.Current != null &&
                Application.Current.Resources.TryGetValue(resourceKey, out var colorValue) &&
                colorValue is Color finalColor)
            {
                return finalColor;
            }

            return Colors.Gray;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
