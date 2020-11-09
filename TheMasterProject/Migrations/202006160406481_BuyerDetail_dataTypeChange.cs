namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuyerDetail_dataTypeChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buyer_Detail", "Gender", c => c.String());
            AlterColumn("dbo.Buyer_Detail", "MaritalStatus", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buyer_Detail", "MaritalStatus", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Buyer_Detail", "Gender", c => c.Boolean(nullable: false));
        }
    }
}
