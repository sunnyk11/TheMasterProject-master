namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectLead : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProjectLeadDetails");
        }
    }
}
