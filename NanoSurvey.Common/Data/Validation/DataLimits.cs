namespace NanoSurvey.Common.Data.Validation
{
    public static class DataLimits
    {
        // Регулярки? Не, не слышал

        public const string ValidUserNameSymbols =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_-.";

        public const string ValidPersonNameSymbols =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-" +
            "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        public const int MinUserNameLength = 5;
        public const int MaxUserNameLength = 24;

        public const int MaxSurveyCountPerRequest = 100;
    }
}
