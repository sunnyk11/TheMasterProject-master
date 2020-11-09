namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnBuyerDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyer_Detail", "LeadCreatedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buyer_Detail", "LeadCreatedBy");
        }
    }
}
