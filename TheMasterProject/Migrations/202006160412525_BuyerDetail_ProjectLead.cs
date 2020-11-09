namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuyerDetail_ProjectLead : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyer_Detail", "ProjectLeadAssigned", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buyer_Detail", "ProjectLeadAssigned");
        }
    }
}
