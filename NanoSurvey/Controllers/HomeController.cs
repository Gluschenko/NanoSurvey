using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NanoSurvey.Common;
using NanoSurvey.Common.Data;
using NanoSurvey.Models;

namespace NanoSurvey.Controllers
{
    public class HomeController : Controller
    {
        readonly ILogger<HomeController> logger;
        readonly SurveyDatabaseContext database;

        public HomeController(ILogger<HomeController> logger, SurveyDatabaseContext database)
        {
            this.logger = logger;
            this.database = database;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("{id}")]
        public IActionResult Poll(int id)
        {
            var survey = database.Surveys.GetByID(id);

            if (survey != null)
                return View(survey);

            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
