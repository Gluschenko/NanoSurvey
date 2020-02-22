using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NanoSurvey.Common;
using NanoSurvey.Common.Data;
using NanoSurvey.API;
using NanoSurvey.Areas.API.Models;
using NanoSurvey.Common.Data.Validation;
using System.ComponentModel.DataAnnotations;

namespace NanoSurvey.Areas.API.Controllers
{
    [Area("API")]
    public class SurveysController : APIControllerBase
    {
        readonly SurveyDatabaseContext database;
        
        public SurveysController(SurveyDatabaseContext database)
        {
            this.database = database;
        }

        [HttpPost]
        public IActionResult GetList(int count, int start = 0) 
        {
            if (count < 1) 
                return JsonError($"Count is too small");

            if (count > DataLimits.MaxSurveyCountPerRequest)
                return JsonError($"Count is too big (max: {DataLimits.MaxSurveyCountPerRequest})");

            return JsonResponce(database.Surveys.GetList(count, start));
        }

        [HttpPost]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                return JsonError("ID must be a positive number");

            var result = database.Surveys.GetByID(id);
            return result != null ? JsonResponce(result) : JsonError("This object is not available");
        }

        [HttpPost]
        public IActionResult GetQuestion(int id, int previous) 
        {
            if (id <= 0)
                return JsonError("ID must be a positive number");

            var question = database.Questions.Get(id, previous);
            /*if (question != null)
            {
                question.Answers = database.Answers.Get(question.ID);
            }*/

            return question != null ? JsonResponce(question) : JsonError("No more questions");
        }

        [HttpPost]
        public IActionResult SaveResult(int interviewID, int questionID, int value)
        {
            var result = database.Results.Save(interviewID, questionID, value);
            database.SaveChanges();

            return JsonResponce(result != null ? 1 : 0);
        }
    }
}
