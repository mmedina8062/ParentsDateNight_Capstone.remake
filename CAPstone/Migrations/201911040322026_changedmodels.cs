namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedmodels : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Sitters", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sitters", "Rating", c => c.String(maxLength: 5));
        }
    }
}
