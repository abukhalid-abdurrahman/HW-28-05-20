using System;

namespace Solution
{
    public class Validator
    {
        public static bool IsDate(string tempDate)
        { 
            DateTime fromDateValue; 
            var formats = new[] { "dd/MM/yyyy", "yyyy-MM-dd", "dd.MM.yyyy" }; 
            if (DateTime.TryParseExact(tempDate, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue))
                return true;
            else
                return false;
        }
    }
}