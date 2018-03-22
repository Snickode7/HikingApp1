namespace HikingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trails",
                c => new
                    {
                        TrailId = c.Int(nullable: false, identity: true),
                        NameOfTrail = c.String(),
                        Date = c.String(),
                        Location = c.String(),
                        LengthOfTrail = c.String(),
                        Difficulty = c.String(),
                        WeatherConditions = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.TrailId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Trails");
        }
    }
}
