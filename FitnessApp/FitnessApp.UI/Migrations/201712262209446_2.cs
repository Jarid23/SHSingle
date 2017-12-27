namespace FitnessApp.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Clients", name: "Trainer_TrainerID1", newName: "ClientTrainer_TrainerID");
            RenameIndex(table: "dbo.Clients", name: "IX_Trainer_TrainerID1", newName: "IX_ClientTrainer_TrainerID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Clients", name: "IX_ClientTrainer_TrainerID", newName: "IX_Trainer_TrainerID1");
            RenameColumn(table: "dbo.Clients", name: "ClientTrainer_TrainerID", newName: "Trainer_TrainerID1");
        }
    }
}
