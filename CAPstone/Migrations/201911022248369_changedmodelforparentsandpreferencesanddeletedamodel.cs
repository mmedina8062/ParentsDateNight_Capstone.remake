namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedmodelforparentsandpreferencesanddeletedamodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PreferencesResults", "ParentID", "dbo.Parents");
            DropForeignKey("dbo.PreferencesResults", "PreferencesID", "dbo.Preferences");
            DropIndex("dbo.PreferencesResults", new[] { "ParentID" });
            DropIndex("dbo.PreferencesResults", new[] { "PreferencesID" });
            DropTable("dbo.PreferencesResults");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PreferencesResults",
                c => new
                    {
                        PreferencesResultsID = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(nullable: false),
                        PreferencesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PreferencesResultsID);
            
            CreateIndex("dbo.PreferencesResults", "PreferencesID");
            CreateIndex("dbo.PreferencesResults", "ParentID");
            AddForeignKey("dbo.PreferencesResults", "PreferencesID", "dbo.Preferences", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PreferencesResults", "ParentID", "dbo.Parents", "Id", cascadeDelete: true);
        }
    }
}
