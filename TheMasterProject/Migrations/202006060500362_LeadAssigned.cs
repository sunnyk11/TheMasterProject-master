namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeadAssigned : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserDetails", "LeadAssigned", c => c.Int(nullable: false));
            CreateIndex("dbo.UserDetails", "LeadAssigned");
            AddForeignKey("dbo.UserDetails", "LeadAssigned", "dbo.ProjectLeadDetails", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDetails", "LeadAssigned", "dbo.ProjectLeadDetails");
            DropIndex("dbo.UserDetails", new[] { "LeadAssigned" });
            AlterColumn("dbo.UserDetails", "LeadAssigned", c => c.String());
        }
    }
}
