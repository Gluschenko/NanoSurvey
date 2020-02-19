using System.Linq;

namespace NanoSurvey.Common.Data
{
    //public delegate void ErrorMessageDelegate(string text);

    public static class Helpers
    {
        public static bool IsValidUserName(string name)
        {
            return name.All(ch => Limits.ValidUsernameSymbols.Contains(name)) && name.Length >= Limits.MinUserNameLength && name.Length <= Limits.MaxUserNameLength;
        }

        public static bool IsValidEmail(string email)
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
        }

        /// <summary>
        /// Конвертирует строку из "joHN" в "John"
        /// </summary>
        /// <returns></returns>
        public static string ToNameCase(string name)
        {
            name = name.Trim();
            return name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
        }
    }
}

