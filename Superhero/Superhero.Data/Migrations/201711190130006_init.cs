namespace Superhero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Heroes",
                c => new
                    {
                        HeroID = c.Int(nullable: false, identity: true),
                        HeroName = c.String(),
                        Description = c.String(),
                        Superpower = c.String(),
                    })
                .PrimaryKey(t => t.HeroID);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        OrganizationID = c.Int(nullable: false, identity: true),
                        OrganizationName = c.String(),
                        OganizationAddress = c.String(),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrganizationID);
            
            CreateTable(
                "dbo.Sightings",
                c => new
                    {
                        SightingID = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                        Date = c.DateTime(nullable: false),
                        Ispublished = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SightingID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                        LocationDescription = c.String(),
                        LocationAddress = c.String(),
                        LatitudeCoordinate = c.Int(nullable: false),
                        LongitudeCoordinate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.SightingHeroes", "Hero_HeroID", "dbo.Heroes");
            DropForeignKey("dbo.SightingHeroes", "Sighting_SightingID", "dbo.Sightings");
            DropForeignKey("dbo.OrganizationHeroes", "Hero_HeroID", "dbo.Heroes");
            DropForeignKey("dbo.OrganizationHeroes", "Organization_OrganizationID", "dbo.Organizations");
            DropIndex("dbo.SightingHeroes", new[] { "Hero_HeroID" });
            DropIndex("dbo.SightingHeroes", new[] { "Sighting_SightingID" });
            DropIndex("dbo.OrganizationHeroes", new[] { "Hero_HeroID" });
            DropIndex("dbo.OrganizationHeroes", new[] { "Organization_OrganizationID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.SightingHeroes");
            DropTable("dbo.OrganizationHeroes");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Locations");
            DropTable("dbo.Sightings");
            DropTable("dbo.Organizations");
            DropTable("dbo.Heroes");
        }
    }
}
