namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmorepropertiestopreferencemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Preferences", "IsChecked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Preferences", "IsChecked");
        }
    }
}
