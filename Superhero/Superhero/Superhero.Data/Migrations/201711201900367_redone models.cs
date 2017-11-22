namespace Superhero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class redonemodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "OrganizationLocation_LocationID", c => c.Int());
            AddColumn("dbo.Sightings", "SightingLocation_LocationID", c => c.Int());
            CreateIndex("dbo.Organizations", "OrganizationLocation_LocationID");
            CreateIndex("dbo.Sightings", "SightingLocation_LocationID");
            AddForeignKey("dbo.Organizations", "OrganizationLocation_LocationID", "dbo.Locations", "LocationID");
            AddForeignKey("dbo.Sightings", "SightingLocation_LocationID", "dbo.Locations", "LocationID");
            DropColumn("dbo.Sightings", "LocationName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sightings", "LocationName", c => c.String());
            DropForeignKey("dbo.Sightings", "SightingLocation_LocationID", "dbo.Locations");
            DropForeignKey("dbo.Organizations", "OrganizationLocation_LocationID", "dbo.Locations");
            DropIndex("dbo.Sightings", new[] { "SightingLocation_LocationID" });
            DropIndex("dbo.Organizations", new[] { "OrganizationLocation_LocationID" });
            DropColumn("dbo.Sightings", "SightingLocation_LocationID");
            DropColumn("dbo.Organizations", "OrganizationLocation_LocationID");
        }
    }
}
