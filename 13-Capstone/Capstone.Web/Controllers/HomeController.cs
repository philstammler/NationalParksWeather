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
        private ISurvey_ResultSqlDao survey_ResultDao;

        public HomeController(IParkDao parkDao, ISurvey_ResultSqlDao survey_ResultDao)
        {
            this.parkDao = parkDao;
            this.survey_ResultDao = survey_ResultDao;
        }

        public IActionResult Index()
        {
            IList<Park> parks = parkDao.GetParks();
            return View(parks);
        }


        public IActionResult Detail(string parkCode)
        {
            Park park = parkDao.GetPark(parkCode);

            ViewBag.Weather = parkDao.GetParkWeather(parkCode);


            return View(park);
        }


        [HttpGet]
        public IActionResult Survey()
        {
            IList<Park> parks = parkDao.GetParks();
            ViewBag.ParkSelectList = parkDao.GetParkSelectList();
            return View();
        }

        [HttpPost]
        public IActionResult Survey(Survey_Result surveyResult)
        {
            surveyResult.State = surveyResult.State.ToUpper();
            survey_ResultDao.AddResult(surveyResult);
            return RedirectToAction("SurveyResults");
        }

        public IActionResult SurveyResults()
        {
            List<SurveyResultViewModel> surveys = new List<SurveyResultViewModel>();
            surveys = survey_ResultDao.GetTopRankedParks();
            return View(surveys);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
