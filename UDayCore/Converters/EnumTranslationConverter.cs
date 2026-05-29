using System.Globalization;
using UDayCore.Helpers;
using UDayCore.Models.Enums;

namespace UDayCore.Converters
{


    public class EnumTranslationConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (parameter?.ToString() == "Status" && value is bool isCompleted)
            {
                return isCompleted ? "Concluída" : "Pendente";
            }

            if (parameter?.ToString() == "IsRecurring" && value is RecurrenceType recurrence)
            {
                return recurrence != RecurrenceType.None;
            }

            if (value is AppTheme theme)
            {
                return theme switch
                {
                    AppTheme.Unspecified => "Sistema",
                    AppTheme.Light => "Claro",
                    AppTheme.Dark => "Escuro",
                     _ => string.Empty
                };
            }

            if (value is Enum enumValue)
                return enumValue.GetDescription();
            
            return value?.ToString() ?? string.Empty;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}