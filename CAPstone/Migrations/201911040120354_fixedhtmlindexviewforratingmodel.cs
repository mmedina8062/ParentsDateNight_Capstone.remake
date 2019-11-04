namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedhtmlindexviewforratingmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "ParentID", "dbo.Parents");
            DropForeignKey("dbo.Ratings", "SitterID", "dbo.Sitters");
            DropIndex("dbo.Ratings", new[] { "ParentID" });
            DropPrimaryKey("dbo.Ratings");
            AddColumn("dbo.Ratings", "RateID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Sitters", "Rating", c => c.String(maxLength: 5));
            AddPrimaryKey("dbo.Ratings", "RateID");
            AddForeignKey("dbo.Ratings", "SitterID", "dbo.Sitters", "Id", cascadeDelete: true);
            DropColumn("dbo.Ratings", "ParentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "ParentID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Ratings", "SitterID", "dbo.Sitters");
            DropPrimaryKey("dbo.Ratings");
            DropColumn("dbo.Sitters", "Rating");
            DropColumn("dbo.Ratings", "RateID");
            AddPrimaryKey("dbo.Ratings", "SitterID");
            CreateIndex("dbo.Ratings", "ParentID");
            AddForeignKey("dbo.Ratings", "SitterID", "dbo.Sitters", "Id");
            AddForeignKey("dbo.Ratings", "ParentID", "dbo.Parents", "Id", cascadeDelete: true);
        }
    }
}
