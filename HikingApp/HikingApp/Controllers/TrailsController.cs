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
       

        public ActionResult TrailHistory()
        {
            using (var trailContext = new TrailContext())
            {
                var trailList = new TrailsListModel
                {
                    // Convert each trail into a TrailsViewModel
                    Trails = trailContext.Trails.Select(m => new TrailsViewModel
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

            
        }

        public ActionResult TrailInfo(int id)
        {
            using (var trailContext = new TrailContext())
            {

                var trail = trailContext.Trails.SingleOrDefault(m => m.TrailId == id);
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

            }
            return new HttpNotFoundResult();
        }


        public ActionResult TrailAdd()
        {
            var trailsViewModel = new TrailsViewModel();

            return View("AddTrail", trailsViewModel);
        }

        public ActionResult AddTrail()
        {
            var trailsViewModel = new TrailsViewModel();

            return View("AddTrail", trailsViewModel);
        }


        [HttpPost]
        public ActionResult AddTrail(TrailsViewModel trailsViewModel)
        {
            using (var trailContext = new TrailContext())
            {

                var trail = new Trail
                {
                    NameOfTrail = trailsViewModel.NameOfTrail,
                    Date = trailsViewModel.Date,
                    Location = trailsViewModel.Location,
                    LengthOfTrail = trailsViewModel.LengthOfTrail,
                    Difficulty = trailsViewModel.Difficulty,
                    WeatherConditions = trailsViewModel.WeatherConditions,
                    Notes = trailsViewModel.Notes
                };

                trailContext.Trails.Add(trail);
                trailContext.SaveChanges();
            }

            return RedirectToAction("TrailHistory");
        }
        
            
        public ActionResult TrailEdit(int id)
        {

            using (var trailContext = new TrailContext())
            {
                var trail = trailContext.Trails.SingleOrDefault(m => m.TrailId == id);
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

                    return View("EditTrail", trailsViewModel);
                }

            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult EditTrail(TrailsViewModel trailsViewModel)
        {
            using (var trailContext = new TrailContext())
            {
                var trail = trailContext.Trails.SingleOrDefault(m => m.TrailId == trailsViewModel.TrailId);

                if (ModelState.IsValid)
                {
                    trail.NameOfTrail = trailsViewModel.NameOfTrail;
                    trail.Date = trailsViewModel.Date;
                    trail.Location = trailsViewModel.Location;
                    trail.LengthOfTrail = trailsViewModel.LengthOfTrail;
                    trail.Difficulty = trailsViewModel.Difficulty;
                    trail.WeatherConditions = trailsViewModel.WeatherConditions;
                    trail.Notes = trailsViewModel.Notes;
                    trailContext.SaveChanges();

                    return RedirectToAction("TrailHistory");
                }

                return new HttpNotFoundResult();

            }

                
         }


        [HttpPost]
        public ActionResult DeleteTrail(TrailsViewModel trailsViewModel)
        {

            using (var trailContext = new TrailContext())
            {
                var trail = trailContext.Trails.SingleOrDefault(m => m.TrailId == trailsViewModel.TrailId);

                if (trail != null)
                {
                    trailContext.Trails.Remove(trail);
                    trailContext.SaveChanges();

                    return RedirectToAction("TrailHistory");
                }
   
            }

            return new HttpNotFoundResult();
        }
    }
}