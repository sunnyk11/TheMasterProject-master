namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuyerDetail_stringpincode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buyer_Detail", "pincode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buyer_Detail", "pincode", c => c.Int(nullable: false));
        }
    }
}
