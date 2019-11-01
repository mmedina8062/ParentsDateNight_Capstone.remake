namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedpreferencemodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Preferences", "IsChecked");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Preferences", "IsChecked", c => c.Boolean(nullable: false));
        }
    }
}
