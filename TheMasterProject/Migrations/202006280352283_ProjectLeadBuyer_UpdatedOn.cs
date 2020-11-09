namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectLeadBuyer_UpdatedOn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BuyerRelationProjectLeads", "UpdatedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BuyerRelationProjectLeads", "UpdatedOn");
        }
    }
}
