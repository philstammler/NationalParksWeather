using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {

        private IParkDao parkDao;
        private readonly ISurvey_ResultSqlDao survey_ResultDao;

        public HomeController(IParkDao parkDao, ISurvey_ResultSqlDao survey_ResultDao)
        {
            this.survey_ResultDao = survey_ResultDao;
            this.parkDao = parkDao;
        }

        public IActionResult Index()
        {
            IList<Park> parks = parkDao.GetParks();
            return View(parks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
