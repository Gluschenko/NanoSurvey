using Microsoft.AspNetCore.Http;

#pragma warning disable IDE1006 // Стили именования

namespace NanoSurvey.API
{
    public struct SuccessResult
    {
        public object response { get; set; }

        public SuccessResult(object obj)
        {
            response = obj;
        }
    }
}

#pragma warning restore IDE1006 // Стили именования

