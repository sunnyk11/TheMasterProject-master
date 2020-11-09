namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveForeginKey_assignedLead : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserDetails", "LeadAssigned", "dbo.ProjectLeadDetails");
            DropIndex("dbo.UserDetails", new[] { "LeadAssigned" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.UserDetails", "LeadAssigned");
            AddForeignKey("dbo.UserDetails", "LeadAssigned", "dbo.ProjectLeadDetails", "Id", cascadeDelete: true);
        }
    }
}
