namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuyerDetail_alreadyloan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyer_Detail", "AlreadyLoan", c => c.Boolean());
            DropColumn("dbo.Buyer_Detail", "AlreadyLoad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Buyer_Detail", "AlreadyLoad", c => c.Boolean(nullable: false));
            DropColumn("dbo.Buyer_Detail", "AlreadyLoan");
        }
    }
}
