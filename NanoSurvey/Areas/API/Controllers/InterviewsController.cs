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
using NanoSurvey.Common.Entities;
using NanoSurvey.Common.Data.Validation;

namespace NanoSurvey.Areas.API.Controllers
{
    [Area("API")]
    public class InterviewsController : APIControllerBase
    {
        readonly SurveyDatabaseContext database;
        
        public InterviewsController(SurveyDatabaseContext database)
        {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Save(InterviewSaveModel model)
        {
            if (!ModelState.IsValid)
                return JsonError(ModelState);

            var interview = (Interview)model;
            interview.Date = DateTime.Now;

            interview = database.Interviews.Create(interview);
            database.SaveChanges();

            return JsonResponce(interview.ID);
        }
    }
}
