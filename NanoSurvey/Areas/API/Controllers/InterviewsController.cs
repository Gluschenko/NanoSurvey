using Microsoft.AspNetCore.Mvc;
using NanoSurvey.API;
using NanoSurvey.Areas.API.Models;
using NanoSurvey.Common;
using NanoSurvey.Common.Data;
using NanoSurvey.Common.Entities;

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
            interview = database.Interviews.Create(interview);
            database.SaveChanges();

            return JsonResponce(interview.ID);
        }
    }
}
