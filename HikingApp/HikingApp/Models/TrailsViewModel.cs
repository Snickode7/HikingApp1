using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace HikingApp.Models
{
    public class TrailsViewModel
    {
        public int? TrailId { get; set; }
        [DisplayName("Name of Trail:")]
        public string NameOfTrail { get; set; }
        [DisplayName("Date:")]
        public string Date { get; set; }
        [DisplayName("Location:")]
        public string Location { get; set; }
        [DisplayName("Length of Trail:")]
        public string LengthOfTrail { get; set; }
        [DisplayName("Difficulty:")]
        public string Difficulty { get; set; }
        [DisplayName("Weather Conditions:")]
        public string WeatherConditions { get; set; }
        [DisplayName("Notes:")]
        public string Notes { get; set; }
    }
}