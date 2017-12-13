namespace Superhero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1st : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organizations", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organizations", "Phone", c => c.Int(nullable: false));
        }
    }
}
