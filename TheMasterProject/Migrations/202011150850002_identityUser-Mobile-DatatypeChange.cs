namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identityUserMobileDatatypeChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "MobileNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "MobileNo", c => c.Int(nullable: false));
        }
    }
}
