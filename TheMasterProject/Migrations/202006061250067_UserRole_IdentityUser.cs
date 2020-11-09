namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRole_IdentityUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserRole");
        }
    }
}
