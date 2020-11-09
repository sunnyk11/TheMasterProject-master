namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDetail_Email_Password : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDetails", "EmailId", c => c.String());
            AddColumn("dbo.UserDetails", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDetails", "Password");
            DropColumn("dbo.UserDetails", "EmailId");
        }
    }
}
