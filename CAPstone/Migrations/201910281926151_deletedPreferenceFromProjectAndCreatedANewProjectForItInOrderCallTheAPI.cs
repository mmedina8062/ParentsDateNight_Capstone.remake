namespace CAPstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedPreferenceFromProjectAndCreatedANewProjectForItInOrderCallTheAPI : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Preferences");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Preferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Preference = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
