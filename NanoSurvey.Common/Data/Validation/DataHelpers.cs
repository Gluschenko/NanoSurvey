using System.Globalization;
using System.Linq;

namespace NanoSurvey.Common.Data.Validation
{
    //public delegate void ErrorMessageDelegate(string text);

    public static class DataHelpers
    {
        /* В двух следующих методах избегалось применение регулярных
         * выражений, так как это создает необходимость в дополнительном
         * сопровождении и покрытии тестами.
         */

        /// <summary>
        /// Проверяет символы и длину логина пользователя
        /// </summary>
        public static bool IsValidUserName(string name)
        {
            return name.All(ch => DataLimits.ValidUserNameSymbols.Contains(ch)) 
                && name.Length >= DataLimits.MinUserNameLength 
                && name.Length <= DataLimits.MaxUserNameLength;
        }

        /// <summary>
        /// Проверяет ограниченность символьного набора в человеческих именах
        /// </summary>
        public static bool IsValidPersonName(string name)
        {
            return name.All(ch => DataLimits.ValidPersonNameSymbols.Contains(ch));
        }

        /// <summary>
        /// Конвертирует строку из "joHN" в "John"
        /// </summary>
        /// <returns></returns>
        public static string ToTitleCase(string name) => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);

        /*public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }*/
    }
}

