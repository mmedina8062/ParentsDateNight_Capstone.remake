namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedback : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Preferences", "Budget");
            DropColumn("dbo.Preferences", "Miles");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Preferences", "Miles", c => c.Int(nullable: false));
            AddColumn("dbo.Preferences", "Budget", c => c.Double(nullable: false));
        }
    }
}
