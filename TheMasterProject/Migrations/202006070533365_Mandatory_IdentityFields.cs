namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mandatory_IdentityFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "DateOfBirth", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "CurrentlyLivingIn", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "MaritalStatus", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "MaritalStatus", c => c.String());
            AlterColumn("dbo.AspNetUsers", "CurrentlyLivingIn", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Gender", c => c.String());
            AlterColumn("dbo.AspNetUsers", "DateOfBirth", c => c.String());
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String());
        }
    }
}
