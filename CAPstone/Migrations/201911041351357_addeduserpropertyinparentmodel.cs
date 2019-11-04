namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeduserpropertyinparentmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parents", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Parents", "UserId");
            AddForeignKey("dbo.Parents", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parents", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Parents", new[] { "UserId" });
            DropColumn("dbo.Parents", "UserId");
        }
    }
}
