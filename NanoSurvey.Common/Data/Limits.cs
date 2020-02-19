namespace NanoSurvey.Common.Data
{
    public static class Limits
    {
        public const string ValidUsernameSymbols =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_-.";

        public const int MinUserNameLength = 5;
        public const int MaxUserNameLength = 24;

        public const int MaxSurveyCountPerRequest = 50;
    }
}
