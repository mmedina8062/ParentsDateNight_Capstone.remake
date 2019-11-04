namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcontrollerandviewsforratingsmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        ParentID = c.Int(nullable: false),
                        SitterID = c.Int(nullable: false),
                        RatingValue = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.ParentID, t.SitterID })
                .ForeignKey("dbo.Parents", t => t.ParentID, cascadeDelete: true)
                .ForeignKey("dbo.Sitters", t => t.SitterID, cascadeDelete: true)
                .Index(t => t.ParentID)
                .Index(t => t.SitterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "SitterID", "dbo.Sitters");
            DropForeignKey("dbo.Ratings", "ParentID", "dbo.Parents");
            DropIndex("dbo.Ratings", new[] { "SitterID" });
            DropIndex("dbo.Ratings", new[] { "ParentID" });
            DropTable("dbo.Ratings");
        }
    }
}
