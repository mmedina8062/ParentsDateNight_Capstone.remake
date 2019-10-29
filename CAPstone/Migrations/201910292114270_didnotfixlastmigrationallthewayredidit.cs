namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class didnotfixlastmigrationallthewayredidit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sitters", "LastName", c => c.String());
            DropColumn("dbo.Sitters", "LastNameInitial");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sitters", "LastNameInitial", c => c.String());
            DropColumn("dbo.Sitters", "LastName");
        }
    }
}
