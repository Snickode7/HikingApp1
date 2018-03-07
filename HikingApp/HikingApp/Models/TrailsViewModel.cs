using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HikingApp.Models
{
    public class TrailsViewModel
    {
        public int? TrailId { get; set; }
        public string NameOfTrail { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string LengthOfTrail { get; set; }
        public string Difficulty { get; set; }
        public string WeatherConditions { get; set; }
        public string Notes { get; set; }
    }
}