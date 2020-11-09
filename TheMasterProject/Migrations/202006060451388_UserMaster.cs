namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserMaster : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserCredentials", "UserId", "dbo.UserDetails");
            DropIndex("dbo.UserCredentials", new[] { "UserId" });
            DropTable("dbo.ProjectLeadDetails");
            DropTable("dbo.UserCredentials");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectLeadDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.String(),
                        CurrentlyLivingIn = c.String(),
                        MaritalStatus = c.String(),
                        AadharCard = c.Int(nullable: false),
                        pincode = c.Int(nullable: false),
                        MobileNo = c.Int(nullable: false),
                        TimestampCreated = c.DateTime(nullable: false),
                        LeadAssigned = c.String(),
                        TimestampUpdated = c.DateTime(),
                        UserType = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UserCredentials", "UserId");
            AddForeignKey("dbo.UserCredentials", "UserId", "dbo.UserDetails", "Id", cascadeDelete: true);
        }
    }
}
