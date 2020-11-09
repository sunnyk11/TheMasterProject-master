namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumn_IdentityUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Gender", c => c.String());
            AddColumn("dbo.AspNetUsers", "CurrentlyLivingIn", c => c.String());
            AddColumn("dbo.AspNetUsers", "MaritalStatus", c => c.String());
            AddColumn("dbo.AspNetUsers", "AadharCard", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "pincode", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "MobileNo", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "LeadAssigned", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserType");
            DropColumn("dbo.AspNetUsers", "LeadAssigned");
            DropColumn("dbo.AspNetUsers", "MobileNo");
            DropColumn("dbo.AspNetUsers", "pincode");
            DropColumn("dbo.AspNetUsers", "AadharCard");
            DropColumn("dbo.AspNetUsers", "MaritalStatus");
            DropColumn("dbo.AspNetUsers", "CurrentlyLivingIn");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
