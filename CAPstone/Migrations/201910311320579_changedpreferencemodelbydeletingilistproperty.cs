namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedpreferencemodelbydeletingilistproperty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Preferences", "Preferences_Id", "dbo.Preferences");
            DropIndex("dbo.Preferences", new[] { "Preferences_Id" });
            DropColumn("dbo.Preferences", "Preferences_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Preferences", "Preferences_Id", c => c.Int());
            CreateIndex("dbo.Preferences", "Preferences_Id");
            AddForeignKey("dbo.Preferences", "Preferences_Id", "dbo.Preferences", "Id");
        }
    }
}
