using System.ComponentModel;
using System.Reflection;

namespace UDayCore.Helpers
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            if (value == null) return string.Empty;

            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field == null) return value.ToString();

            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                return attribute.Description;

            return value.ToString();
        }
    }
}