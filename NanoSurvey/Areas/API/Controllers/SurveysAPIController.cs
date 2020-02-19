using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NanoSurvey.Models;
using NanoSurvey.Common;
using NanoSurvey.Common.Data;
using NanoSurvey.API;
using NanoSurvey.Areas.API.Models;

namespace NanoSurvey.Areas.API.Controllers
{
    [Route("api/surveys")]
    public class SurveysAPIController : APIControllerBase<SurveysAPIController>
    {
        readonly SurveyDatabaseContext databaseContext;
        
        public SurveysAPIController(SurveyDatabaseContext context, ILogger<SurveysAPIController> logger) : base(logger)
        {
            databaseContext = context;
        }

        [Route("getList")]
        public IActionResult GetList(int count, int offset) 
        {
            if (count > Limits.MaxSurveyCountPerRequest)
                return JsonError($"Count is too big (max: {Limits.MaxSurveyCountPerRequest})");

            return JsonResponce(databaseContext.Surveys.GetList(count, offset));
        }

        [Route("get")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                return JsonError("ID must be a positive number");

            var result = databaseContext.Surveys.GetByID(id);
            return result != null ? 
                JsonResponce(result) : 
                JsonError("This object isn't available");
        }

        [Route("saveResults")]
        public IActionResult SaveResults(ServeySaveResultsModel model)
        {
            if (!ModelState.IsValid)
                return JsonError(model);

            return JsonResponce("OK");
        }
    }
}
