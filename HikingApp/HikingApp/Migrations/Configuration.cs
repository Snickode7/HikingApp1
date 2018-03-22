using HikingApp.Models;
using System.Data.Entity.Migrations;

namespace HikingApp.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TrailContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TrailContext context)
        {
            context.Trails.AddOrUpdate(
                m => m.TrailId,
                 new Trail
                 {
                     TrailId = 1,
                     NameOfTrail = "Auxier Ridge Loop",
                     Date = "August 9, 2017",
                     Location = "Red River Gorge",
                     LengthOfTrail = "5 miles",
                     Difficulty = "Hard",
                     WeatherConditions = "Sunny and Hot",
                     Notes = "One of the best hikes in Ky!!"
                 }
            );
        }
    }
}

