namespace Superhero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M2M : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrganizationHeroes", "Organization_OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.OrganizationHeroes", "Hero_HeroID", "dbo.Heroes");
            DropForeignKey("dbo.SightingHeroes", "Sighting_SightingID", "dbo.Sightings");
            DropForeignKey("dbo.SightingHeroes", "Hero_HeroID", "dbo.Heroes");
            DropIndex("dbo.OrganizationHeroes", new[] { "Organization_OrganizationID" });
            DropIndex("dbo.OrganizationHeroes", new[] { "Hero_HeroID" });
            DropIndex("dbo.SightingHeroes", new[] { "Sighting_SightingID" });
            DropIndex("dbo.SightingHeroes", new[] { "Hero_HeroID" });
            DropTable("dbo.OrganizationHeroes");
            DropTable("dbo.SightingHeroes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SightingHeroes",
                c => new
                    {
                        Sighting_SightingID = c.Int(nullable: false),
                        Hero_HeroID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sighting_SightingID, t.Hero_HeroID });
            
            CreateTable(
                "dbo.OrganizationHeroes",
                c => new
                    {
                        Organization_OrganizationID = c.Int(nullable: false),
                        Hero_HeroID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Organization_OrganizationID, t.Hero_HeroID });
            
            CreateIndex("dbo.SightingHeroes", "Hero_HeroID");
            CreateIndex("dbo.SightingHeroes", "Sighting_SightingID");
            CreateIndex("dbo.OrganizationHeroes", "Hero_HeroID");
            CreateIndex("dbo.OrganizationHeroes", "Organization_OrganizationID");
            AddForeignKey("dbo.SightingHeroes", "Hero_HeroID", "dbo.Heroes", "HeroID", cascadeDelete: true);
            AddForeignKey("dbo.SightingHeroes", "Sighting_SightingID", "dbo.Sightings", "SightingID", cascadeDelete: true);
            AddForeignKey("dbo.OrganizationHeroes", "Hero_HeroID", "dbo.Heroes", "HeroID", cascadeDelete: true);
            AddForeignKey("dbo.OrganizationHeroes", "Organization_OrganizationID", "dbo.Organizations", "OrganizationID", cascadeDelete: true);
        }
    }
}
