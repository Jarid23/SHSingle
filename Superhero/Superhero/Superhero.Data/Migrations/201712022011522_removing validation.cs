namespace Superhero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removingvalidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organizations", "OrganizationName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organizations", "OrganizationName", c => c.String(nullable: false));
        }
    }
}
