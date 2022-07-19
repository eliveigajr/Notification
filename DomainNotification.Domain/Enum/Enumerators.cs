using System.ComponentModel;

namespace DomainNotification.Domain.Enum
{
    public static class Enumerators
    {
        public static string GetDescription(object value)
        {
            var enumType = value.GetType();
            var field = enumType.GetField(value.ToString());
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}
