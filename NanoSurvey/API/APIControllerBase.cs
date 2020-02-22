using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NanoSurvey.API
{
    /// <summary>
    /// Является базовым для всех контроллеров API. 
    /// Предоставляет обработку атрибута, требующиего авторизацию пользователя. 
    /// </summary>
    public abstract class APIControllerBase : Controller
    {
        public IActionResult Index() => Json(new ErrorResult("Method is empty or null", HttpContext));

        // Оборачивает результат в условно стандартный ответ API
        protected IActionResult JsonResponce(object obj) => Json(new SuccessResult(obj));

        protected IActionResult JsonError(object obj) => Json(new ErrorResult(obj, HttpContext));

        protected IActionResult JsonError(ModelStateDictionary state)
        {
            var res = state.SelectMany((item) => item.Value.Errors, (item, error) => error.ErrorMessage.Replace("'", "|"));
            return JsonError(res);
        }
    }
}
