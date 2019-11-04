namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedlatandlongtopreferencetobeabletoholdvalue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Preferences", "LatLong", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Preferences", "LatLong");
        }
    }
}
