namespace Superhero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class morevaidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organizations", "OrganizationName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organizations", "OrganizationName", c => c.String());
        }
    }
}
