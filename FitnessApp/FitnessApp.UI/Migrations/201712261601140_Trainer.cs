namespace FitnessApp.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrainerUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "Trainer_TrainerID", "dbo.Trainers");
            AddColumn("dbo.Clients", "Trainer_TrainerID1", c => c.Int());
            AddColumn("dbo.Trainers", "Client_ClientID", c => c.Int());
            CreateIndex("dbo.Clients", "Trainer_TrainerID1");
            CreateIndex("dbo.Trainers", "Client_ClientID");
            AddForeignKey("dbo.Trainers", "Client_ClientID", "dbo.Clients", "ClientID");
            AddForeignKey("dbo.Clients", "Trainer_TrainerID1", "dbo.Trainers", "TrainerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "Trainer_TrainerID1", "dbo.Trainers");
            DropForeignKey("dbo.Trainers", "Client_ClientID", "dbo.Clients");
            DropIndex("dbo.Trainers", new[] { "Client_ClientID" });
            DropIndex("dbo.Clients", new[] { "Trainer_TrainerID1" });
            DropColumn("dbo.Trainers", "Client_ClientID");
            DropColumn("dbo.Clients", "Trainer_TrainerID1");
            AddForeignKey("dbo.Clients", "Trainer_TrainerID", "dbo.Trainers", "TrainerID");
        }
    }
}
