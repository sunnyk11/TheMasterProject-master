namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumntoDealerToLeadRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DealerToLeadRelations", "LeadVerifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DealerToLeadRelations", "LeadVerifiedBy");
        }
    }
}
