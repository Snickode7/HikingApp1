using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HikingApp.Models;

namespace HikingApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TrailHistory()
        {
            var trailsList = new TrailsListModel
            {
                Trails = new List<TrailsModel>
                {
                    new TrailsModel { TrailId = 1, NameOfTrail = "Auxier Ridge Loop", Date = "August 9, 2017",
                                    Location = "Red River Gorge", LengthOfTrail = "5 miles", Difficulty = "Hard",
                                    WeatherConditions = "Sunny and Hot", Notes = "One of the best hikes in Ky!!" }
                }
            };
            return View(trailsList);
        }
    }
}