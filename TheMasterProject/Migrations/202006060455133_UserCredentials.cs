namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserCredentials : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCredentials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailId = c.String(),
                        Password = c.String(),
                        TimeStampCreated = c.DateTime(nullable: false),
                        TimeStampUpdated = c.DateTime(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserDetails", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCredentials", "UserId", "dbo.UserDetails");
            DropIndex("dbo.UserCredentials", new[] { "UserId" });
            DropTable("dbo.UserCredentials");
        }
    }
}
