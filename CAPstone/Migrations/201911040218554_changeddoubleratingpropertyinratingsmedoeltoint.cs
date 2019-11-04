namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeddoubleratingpropertyinratingsmedoeltoint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ratings", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ratings", "Rating", c => c.Double(nullable: false));
        }
    }
}
