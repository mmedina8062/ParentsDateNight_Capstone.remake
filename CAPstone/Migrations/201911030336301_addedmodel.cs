namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "Rating", c => c.Double(nullable: false));
            DropColumn("dbo.Ratings", "RatingValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "RatingValue", c => c.Double(nullable: false));
            DropColumn("dbo.Ratings", "Rating");
        }
    }
}
