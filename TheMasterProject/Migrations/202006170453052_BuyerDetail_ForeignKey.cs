namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuyerDetail_ForeignKey : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buyer_Detail", "ProjectLeadAssigned", c => c.String(maxLength: 128));
            CreateIndex("dbo.Buyer_Detail", "ProjectLeadAssigned");
            AddForeignKey("dbo.Buyer_Detail", "ProjectLeadAssigned", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Buyer_Detail", "ProjectLeadAssigned", "dbo.AspNetUsers");
            DropIndex("dbo.Buyer_Detail", new[] { "ProjectLeadAssigned" });
            AlterColumn("dbo.Buyer_Detail", "ProjectLeadAssigned", c => c.String());
        }
    }
}
