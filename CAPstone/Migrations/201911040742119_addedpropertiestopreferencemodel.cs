namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpropertiestopreferencemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Preferences", "Budget", c => c.Double(nullable: false));
            AddColumn("dbo.Preferences", "Miles", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Preferences", "Miles");
            DropColumn("dbo.Preferences", "Budget");
        }
    }
}
