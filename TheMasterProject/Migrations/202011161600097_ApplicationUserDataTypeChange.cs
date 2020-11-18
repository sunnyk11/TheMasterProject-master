namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserDataTypeChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "AadharCard", c => c.String());
            AlterColumn("dbo.AspNetUsers", "pincode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "pincode", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "AadharCard", c => c.Int(nullable: false));
        }
    }
}
