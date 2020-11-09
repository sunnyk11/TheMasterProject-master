namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectLead_Email_Password : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectLeadDetails", "EmailId", c => c.String());
            AddColumn("dbo.ProjectLeadDetails", "Password", c => c.String());
            DropColumn("dbo.ProjectLeadDetails", "LeadAssigned");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectLeadDetails", "LeadAssigned", c => c.String());
            DropColumn("dbo.ProjectLeadDetails", "Password");
            DropColumn("dbo.ProjectLeadDetails", "EmailId");
        }
    }
}
