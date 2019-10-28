namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedpropertyforaddressinparentsmodelfrominttostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parents", "StreetAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parents", "StreetAddress", c => c.Int(nullable: false));
        }
    }
}
