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



        public static List<Trail> Trails = new List<Trail>
        {
            new Trail { TrailId = 1, NameOfTrail = "Auxier Ridge Loop", Date = "August 9, 2017",
                        Location = "Red River Gorge", LengthOfTrail = "5 miles", Difficulty = "Hard",
                        WeatherConditions = "Sunny and Hot", Notes = "One of the best hikes in Ky!!" }
        };

        [HttpPost]
        public ActionResult AddTrail(TrailsViewModel trailsViewModel)
        {
            var nextTrailId = Trails.Max(m => m.TrailId) + 1;

            var trail = new Trail
            {
                TrailId = nextTrailId,
                NameOfTrail = trailsViewModel.NameOfTrail,
                Date = trailsViewModel.Date,
                Location = trailsViewModel.Location,
                LengthOfTrail = trailsViewModel.LengthOfTrail,
                Difficulty = trailsViewModel.Difficulty,
                WeatherConditions = trailsViewModel.WeatherConditions,
                Notes = trailsViewModel.Notes
            };

            Trails.Add(trail);

            return View("TrailHistory");
        }

        public ActionResult AddTrail()
        {
            var trailsViewModel = new TrailsViewModel();

            return View("AddTrail", trailsViewModel);
        }


    }

}
