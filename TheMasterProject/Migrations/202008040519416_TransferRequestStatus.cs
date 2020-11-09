namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransferRequestStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyer_Detail", "TransferRequestStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buyer_Detail", "TransferRequestStatus");
        }
    }
}
