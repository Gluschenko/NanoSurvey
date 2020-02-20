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
using NanoSurvey.Common.Data.Validation;

namespace NanoSurvey.Areas.API.Controllers
{
    [Route("api/surveys")]
    public class SurveysAPIController : APIControllerBase<SurveysAPIController>
    {
        readonly SurveyDatabaseContext database;
        
        public SurveysAPIController(SurveyDatabaseContext database, ILogger<SurveysAPIController> logger) : base(logger)
        {
            this.database = database;
        }

        [Route("getList")]
        public IActionResult GetList(int count, int offset) 
        {
            if (count > DataLimits.MaxSurveyCountPerRequest)
                return JsonError($"Count is too big (max: {DataLimits.MaxSurveyCountPerRequest})");

            return JsonResponce(database.Surveys.GetList(count, offset));
        }

        [Route("get")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                return JsonError("ID must be a positive number");

            var result = database.Surveys.GetByID(id);
            return result != null ? 
                JsonResponce(result) : 
                JsonError("This object is not available");
        }

        [Route("saveResults")]
        public IActionResult SaveResults(ServeySaveResultsModel model)
        {
            if (!ModelState.IsValid)
                return JsonError(ModelState);

            return JsonResponce(model);
        }
    }
}
