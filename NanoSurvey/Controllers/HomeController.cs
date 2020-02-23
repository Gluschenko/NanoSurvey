using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NanoSurvey.Common;
using NanoSurvey.Common.Data;

namespace NanoSurvey.Controllers
{
    public class HomeController : Controller
    {
        readonly SurveyDatabaseContext database;

        public HomeController(SurveyDatabaseContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("poll{id}")]
        public IActionResult Poll(int id)
        {
            var survey = database.Surveys.GetByID(id);

            if (survey != null)
                return View(survey);

            return NotFound();
        }

        // Заполняет базу данных тестовыми данными (чем больше запросов, тем толще база)
        [Route("fill/{iterations?}")]
        public IActionResult Fill(int iterations = 50)
        {
            DatabaseLitter.Fill(database, iterations);

            return Content("OK");
        }
    }
}
