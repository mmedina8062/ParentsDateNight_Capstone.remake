namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deledtedpropertiesandaddedcommentpropertyinratingsmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "SitterID", "dbo.Sitters");
            DropPrimaryKey("dbo.Ratings");
            AddColumn("dbo.Ratings", "Comments", c => c.String());
            AddPrimaryKey("dbo.Ratings", "SitterID");
            AddForeignKey("dbo.Ratings", "SitterID", "dbo.Sitters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "SitterID", "dbo.Sitters");
            DropPrimaryKey("dbo.Ratings");
            DropColumn("dbo.Ratings", "Comments");
            AddPrimaryKey("dbo.Ratings", new[] { "ParentID", "SitterID" });
            AddForeignKey("dbo.Ratings", "SitterID", "dbo.Sitters", "Id", cascadeDelete: true);
        }
    }
}
