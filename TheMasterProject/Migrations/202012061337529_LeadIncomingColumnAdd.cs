namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeadIncomingColumnAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyer_Detail", "LeadIncomingFrom", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buyer_Detail", "LeadIncomingFrom");
        }
    }
}
