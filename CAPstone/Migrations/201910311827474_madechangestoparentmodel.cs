namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madechangestoparentmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parents", "Budget", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parents", "Budget", c => c.Int(nullable: false));
        }
    }
}
