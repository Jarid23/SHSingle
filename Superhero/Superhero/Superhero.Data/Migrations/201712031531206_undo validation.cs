namespace Superhero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class undovalidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Heroes", "HeroName", c => c.String());
            AlterColumn("dbo.Locations", "LocationName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "LocationName", c => c.String(nullable: false));
            AlterColumn("dbo.Heroes", "HeroName", c => c.String(nullable: false));
        }
    }
}
