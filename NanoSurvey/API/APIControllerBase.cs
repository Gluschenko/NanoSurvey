using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace NanoSurvey.API
{
    /// <summary>
    /// Является базовым для всех контроллеров API. 
    /// Предоставляет обработку атрибута, требующиего авторизацию пользователя. 
    /// </summary>
    public abstract class APIControllerBase<T> : Controller
    {
        protected readonly ILogger<T> Logger;

        public APIControllerBase(ILogger<T> logger)
        {
            Logger = logger;
        }

        public IActionResult Index() => Json(new ErrorResult("Method is empty or null", HttpContext));

        /// <summary>
        /// Оборачивает результат метода в стандартный ответ API
        /// </summary>
        /// <returns>Json</returns>
        protected IActionResult JsonResponce(object obj) => Json(new SuccessResult(obj));

        /// <summary>
        /// Оборачивает результат метода в стандартный ответ API об ошибке
        /// </summary>
        /// <returns>Json</returns>
        protected IActionResult JsonError(object obj) => Json(new ErrorResult(obj, HttpContext));

        /// <summary>
        /// Оборачивает результат метода в стандартный ответ API об ошибке
        /// </summary>
        /// <param name="state"></param>
        /// <returns>Json</returns>
        protected IActionResult JsonError(ModelStateDictionary state)
        {
            var res = state.SelectMany((item) => item.Value.Errors, (item, error) => error.ErrorMessage.Replace("'", "|"));
            return JsonError(res);
        }
    }
}
