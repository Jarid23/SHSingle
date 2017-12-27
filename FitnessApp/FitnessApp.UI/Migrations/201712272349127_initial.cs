namespace FitnessApp.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        ClientName = c.String(),
                        ClientJoinDate = c.DateTime(nullable: false),
                        StartingWeight = c.Int(nullable: false),
                        CurrentWeight = c.Int(nullable: false),
                        FitnessGoals = c.String(),
                        Trainer_TrainerID = c.Int(),
                        ClientTrainer_TrainerID = c.Int(),
                        Workout_WorkoutID = c.Int(),
                    })
                .PrimaryKey(t => t.ClientID)
                .ForeignKey("dbo.Trainers", t => t.Trainer_TrainerID)
                .ForeignKey("dbo.Trainers", t => t.ClientTrainer_TrainerID)
                .ForeignKey("dbo.Workouts", t => t.Workout_WorkoutID)
                .Index(t => t.Trainer_TrainerID)
                .Index(t => t.ClientTrainer_TrainerID)
                .Index(t => t.Workout_WorkoutID);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        TrainerID = c.Int(nullable: false, identity: true),
                        TrainerName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        HourlyRate = c.Int(nullable: false),
                        Client_ClientID = c.Int(),
                        Workout_WorkoutID = c.Int(),
                    })
                .PrimaryKey(t => t.TrainerID)
                .ForeignKey("dbo.Clients", t => t.Client_ClientID)
                .ForeignKey("dbo.Workouts", t => t.Workout_WorkoutID)
                .Index(t => t.Client_ClientID)
                .Index(t => t.Workout_WorkoutID);
            
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
                "dbo.Workouts",
                c => new
                    {
                        WorkoutID = c.Int(nullable: false, identity: true),
                        WorkoutName = c.String(),
                        WorkoutDescription = c.String(),
                    })
                .PrimaryKey(t => t.WorkoutID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainers", "Workout_WorkoutID", "dbo.Workouts");
            DropForeignKey("dbo.Clients", "Workout_WorkoutID", "dbo.Workouts");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Trainers", "Client_ClientID", "dbo.Clients");
            DropForeignKey("dbo.Clients", "ClientTrainer_TrainerID", "dbo.Trainers");
            DropForeignKey("dbo.Clients", "Trainer_TrainerID", "dbo.Trainers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Trainers", new[] { "Workout_WorkoutID" });
            DropIndex("dbo.Trainers", new[] { "Client_ClientID" });
            DropIndex("dbo.Clients", new[] { "Workout_WorkoutID" });
            DropIndex("dbo.Clients", new[] { "ClientTrainer_TrainerID" });
            DropIndex("dbo.Clients", new[] { "Trainer_TrainerID" });
            DropTable("dbo.Workouts");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Trainers");
            DropTable("dbo.Clients");
        }
    }
}
