namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedbudgetandmilespropertyfrombeingaforeignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sitters", "Parent_Id", "dbo.Parents");
            DropIndex("dbo.Sitters", new[] { "Parent_Id" });
            DropColumn("dbo.Sitters", "Parent_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sitters", "Parent_Id", c => c.Int());
            CreateIndex("dbo.Sitters", "Parent_Id");
            AddForeignKey("dbo.Sitters", "Parent_Id", "dbo.Parents", "Id");
        }
    }
}
