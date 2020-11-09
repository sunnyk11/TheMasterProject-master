namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Buyer_details_Add_columns_FirstMiddleLast : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyer_Detail", "BuyerMiddleName", c => c.String());
            AddColumn("dbo.Buyer_Detail", "BuyerLastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buyer_Detail", "BuyerLastName");
            DropColumn("dbo.Buyer_Detail", "BuyerMiddleName");
        }
    }
}
