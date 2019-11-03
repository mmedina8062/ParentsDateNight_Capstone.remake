namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedorderofpropertyinpreferencemodelandaddedpreferenceresultsmodeltostoreselectedpreferences : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PreferencesResults",
                c => new
                    {
                        PreferencesResultsID = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(nullable: false),
                        PreferencesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PreferencesResultsID)
                .ForeignKey("dbo.Parents", t => t.ParentID, cascadeDelete: true)
                .ForeignKey("dbo.Preferences", t => t.PreferencesID, cascadeDelete: true)
                .Index(t => t.ParentID)
                .Index(t => t.PreferencesID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PreferencesResults", "PreferencesID", "dbo.Preferences");
            DropForeignKey("dbo.PreferencesResults", "ParentID", "dbo.Parents");
            DropIndex("dbo.PreferencesResults", new[] { "PreferencesID" });
            DropIndex("dbo.PreferencesResults", new[] { "ParentID" });
            DropTable("dbo.PreferencesResults");
        }
    }
}
