using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HikingApp.Models;

namespace HikingApp.Controllers
{
    public class TrailsController : Controller
    {
        // GET: Trail
        public static List<Trail> Trails = new List<Trail>
        {
            new Trail {TrailId = 1, NameOfTrail = "Auxier Ridge Loop", Date = "August 9, 2017",
                       Location = "Red River Gorge", LengthOfTrail = "5 miles", Difficulty = "Hard",
                       WeatherConditions = "Sunny and Hot", Notes = "One of the best hikes in Ky!!"}
        };

        public ActionResult TrailHistory()
        {
            var trailList = new TrailsListModel
            {
                // Convert each trail into a TrailsViewModel
                Trails = Trails.Select(m => new TrailsViewModel
                {
                    TrailId = m.TrailId,
                    NameOfTrail = m.NameOfTrail,
                    Date = m.Date,
                    Location = m.Location,
                    LengthOfTrail = m.LengthOfTrail,
                    Difficulty = m.Difficulty,
                    WeatherConditions = m.WeatherConditions,
                    Notes = m.Notes


                }).ToList()
            };

            return View(trailList);
        }

        public ActionResult TrailInfo(int id)
        {
            var trail = Trails.SingleOrDefault(m => m.TrailId == id);
            if (trail != null)
            {
                var trailsViewModel = new TrailsViewModel
                {
                    TrailId = trail.TrailId,
                    NameOfTrail = trail.NameOfTrail,
                    Date = trail.Date,
                    Location = trail.Location,
                    LengthOfTrail = trail.LengthOfTrail,
                    Difficulty = trail.Difficulty,
                    WeatherConditions = trail.WeatherConditions,
                    Notes = trail.Notes
                };

                return View(trailsViewModel);
            }

            return new HttpNotFoundResult();
        }
    }
}