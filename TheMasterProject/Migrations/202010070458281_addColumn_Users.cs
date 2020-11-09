namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumn_Users : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LeadCreated", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LeadCreated");
        }
    }
}
