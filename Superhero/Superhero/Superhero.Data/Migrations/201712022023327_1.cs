namespace Superhero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locations", "LocationName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "LocationName", c => c.String(nullable: false));
        }
    }
}
