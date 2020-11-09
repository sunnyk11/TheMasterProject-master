namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuyerDetail_currentStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyer_Detail", "currenStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buyer_Detail", "currenStatus");
        }
    }
}
