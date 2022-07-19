using System;
using System.Globalization;

namespace DomainNotification.Prompt.Utils
{
    public static class FormatDate
    {
        public static DateTime Convert(string date) => DateTime.ParseExact(date.Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
    }
}
