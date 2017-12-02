namespace Superhero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sightings", "SightingLocation_LocationID", "dbo.Locations");
            DropIndex("dbo.Sightings", new[] { "SightingLocation_LocationID" });
            AlterColumn("dbo.Heroes", "HeroName", c => c.String(nullable: false));
            AlterColumn("dbo.Organizations", "OrganizationName", c => c.String(nullable: false));
            AlterColumn("dbo.Locations", "LocationName", c => c.String(nullable: false));
            AlterColumn("dbo.Sightings", "SightingLocation_LocationID", c => c.Int(nullable: false));
            CreateIndex("dbo.Sightings", "SightingLocation_LocationID");
            AddForeignKey("dbo.Sightings", "SightingLocation_LocationID", "dbo.Locations", "LocationID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sightings", "SightingLocation_LocationID", "dbo.Locations");
            DropIndex("dbo.Sightings", new[] { "SightingLocation_LocationID" });
            AlterColumn("dbo.Sightings", "SightingLocation_LocationID", c => c.Int());
            AlterColumn("dbo.Locations", "LocationName", c => c.String());
            AlterColumn("dbo.Organizations", "OrganizationName", c => c.String());
            AlterColumn("dbo.Heroes", "HeroName", c => c.String());
            CreateIndex("dbo.Sightings", "SightingLocation_LocationID");
            AddForeignKey("dbo.Sightings", "SightingLocation_LocationID", "dbo.Locations", "LocationID");
        }
    }
}
