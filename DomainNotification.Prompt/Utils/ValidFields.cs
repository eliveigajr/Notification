using System;
using System.Text.RegularExpressions;

namespace DomainNotification.Prompt.Utils
{
    public static class ValidFields
    {
        public static bool Date(string referenceDate) => !Regex.IsMatch(referenceDate.Trim(), @"^\d{2}/\d{2}/\d{4}$");

        public static bool Number(string numberTrades) => !Regex.IsMatch(numberTrades.Trim(), @"^[0-9]+$");

        public static bool Sector(string sector) => !sector.Trim().Equals("Private")
                                                 && !sector.Trim().Equals("Public");
    }
}
