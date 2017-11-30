namespace Superhero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dropdown : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sightings", "SightingDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sightings", "SightingDescription");
        }
    }
}
