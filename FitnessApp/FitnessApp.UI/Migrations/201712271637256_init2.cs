namespace FitnessApp.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Workouts", new[] { "TrainerCreator_TrainerID" });
            RenameColumn(table: "dbo.Trainers", name: "TrainerCreator_TrainerID", newName: "Workout_WorkoutID");
            AddColumn("dbo.Clients", "ClientTrainer_TrainerID", c => c.Int());
            AddColumn("dbo.Trainers", "Client_ClientID", c => c.Int());
            CreateIndex("dbo.Clients", "ClientTrainer_TrainerID");
            CreateIndex("dbo.Trainers", "Client_ClientID");
            CreateIndex("dbo.Trainers", "Workout_WorkoutID");
            AddForeignKey("dbo.Clients", "ClientTrainer_TrainerID", "dbo.Trainers", "TrainerID");
            AddForeignKey("dbo.Trainers", "Client_ClientID", "dbo.Clients", "ClientID");
            DropColumn("dbo.Workouts", "TrainerCreator_TrainerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workouts", "TrainerCreator_TrainerID", c => c.Int());
            DropForeignKey("dbo.Trainers", "Client_ClientID", "dbo.Clients");
            DropForeignKey("dbo.Clients", "ClientTrainer_TrainerID", "dbo.Trainers");
            DropIndex("dbo.Trainers", new[] { "Workout_WorkoutID" });
            DropIndex("dbo.Trainers", new[] { "Client_ClientID" });
            DropIndex("dbo.Clients", new[] { "ClientTrainer_TrainerID" });
            DropColumn("dbo.Trainers", "Client_ClientID");
            DropColumn("dbo.Clients", "ClientTrainer_TrainerID");
            RenameColumn(table: "dbo.Trainers", name: "Workout_WorkoutID", newName: "TrainerCreator_TrainerID");
            CreateIndex("dbo.Workouts", "TrainerCreator_TrainerID");
        }
    }
}
