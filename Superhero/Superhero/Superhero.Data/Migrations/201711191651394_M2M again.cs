namespace Superhero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M2Magain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrganizationHeroes",
                c => new
                    {
                        Organization_OrganizationID = c.Int(nullable: false),
                        Hero_HeroID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Organization_OrganizationID, t.Hero_HeroID })
                .ForeignKey("dbo.Organizations", t => t.Organization_OrganizationID, cascadeDelete: true)
                .ForeignKey("dbo.Heroes", t => t.Hero_HeroID, cascadeDelete: true)
                .Index(t => t.Organization_OrganizationID)
                .Index(t => t.Hero_HeroID);
            
            CreateTable(
                "dbo.SightingHeroes",
                c => new
                    {
                        Sighting_SightingID = c.Int(nullable: false),
                        Hero_HeroID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sighting_SightingID, t.Hero_HeroID })
                .ForeignKey("dbo.Sightings", t => t.Sighting_SightingID, cascadeDelete: true)
                .ForeignKey("dbo.Heroes", t => t.Hero_HeroID, cascadeDelete: true)
                .Index(t => t.Sighting_SightingID)
                .Index(t => t.Hero_HeroID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SightingHeroes", "Hero_HeroID", "dbo.Heroes");
            DropForeignKey("dbo.SightingHeroes", "Sighting_SightingID", "dbo.Sightings");
            DropForeignKey("dbo.OrganizationHeroes", "Hero_HeroID", "dbo.Heroes");
            DropForeignKey("dbo.OrganizationHeroes", "Organization_OrganizationID", "dbo.Organizations");
            DropIndex("dbo.SightingHeroes", new[] { "Hero_HeroID" });
            DropIndex("dbo.SightingHeroes", new[] { "Sighting_SightingID" });
            DropIndex("dbo.OrganizationHeroes", new[] { "Hero_HeroID" });
            DropIndex("dbo.OrganizationHeroes", new[] { "Organization_OrganizationID" });
            DropTable("dbo.SightingHeroes");
            DropTable("dbo.OrganizationHeroes");
        }
    }
}
