namespace DVDLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dvds",
                c => new
                    {
                        DvdID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Notes = c.String(),
                        ReleaseYear = c.Int(nullable: false),
                        Director = c.String(),
                        Rating = c.String(),
                    })
                .PrimaryKey(t => t.DvdID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dvds");
        }
    }
}
