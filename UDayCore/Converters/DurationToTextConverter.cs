using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace UDayCore.Converters
{
    public class DurationToTextConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int minutes)
            {
                if (minutes < 60)
                {
                    return $"{minutes}m";
                }

                int hours = minutes / 60;
                int remainingMinutes = minutes % 60;

                if (remainingMinutes == 0)
                {
                    return $"{hours}h 00m";
                }

                return $"{hours}h {remainingMinutes:D2}m";
            }

            return value?.ToString() ?? string.Empty;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
