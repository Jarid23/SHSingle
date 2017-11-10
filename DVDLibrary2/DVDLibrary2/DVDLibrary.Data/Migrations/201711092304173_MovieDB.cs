namespace DVDLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dvds", "realeaseYear", c => c.Int(nullable: false));
            DropColumn("dbo.Dvds", "ReleaseYear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dvds", "ReleaseYear", c => c.Int(nullable: false));
            DropColumn("dbo.Dvds", "realeaseYear");
        }
    }
}
