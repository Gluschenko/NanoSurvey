using Microsoft.AspNetCore.Http;

#pragma warning disable IDE1006 // Стили именования

namespace NanoSurvey.API
{
    public struct ErrorResult
    {
        public object error { get; set; }

        public ErrorResult(object message, HttpContext context)
        {
            bool isPost = context.Request.Method == "POST";

            object request_params = isPost ? (object)context.Request.Form : (object)context.Request.Query;

            error = new ErrorData(message, request_params);
        }

        public ErrorResult(string message, HttpContext context)
        {
            error = new ErrorData(message, context.Request.Query);
        }

        public struct ErrorData
        {
            public object error_msg { get; set; }
            public object request_params { get; set; }

            public ErrorData(object errorMsg, object requestParams)
            {
                error_msg = errorMsg;
                request_params = requestParams;
            }
        }
    }
}

#pragma warning restore IDE1006 // Стили именования

