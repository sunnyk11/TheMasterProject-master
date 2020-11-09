namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class buyerDetailupdateDatatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buyer_Detail", "City", c => c.Int());
            AlterColumn("dbo.Buyer_Detail", "State", c => c.Int());
            AlterColumn("dbo.Buyer_Detail", "OfficeCity", c => c.Int());
            AlterColumn("dbo.Buyer_Detail", "OfficeState", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buyer_Detail", "OfficeState", c => c.String());
            AlterColumn("dbo.Buyer_Detail", "OfficeCity", c => c.String());
            AlterColumn("dbo.Buyer_Detail", "State", c => c.String());
            AlterColumn("dbo.Buyer_Detail", "City", c => c.String());
        }
    }
}
