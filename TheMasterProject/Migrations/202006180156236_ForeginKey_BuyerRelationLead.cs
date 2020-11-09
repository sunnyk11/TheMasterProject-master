namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeginKey_BuyerRelationLead : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BuyerRelationProjectLeads", "BuyerId", "dbo.BuyerRelationProjectLeads");
            AddColumn("dbo.BuyerRelationProjectLeads", "MemberId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BuyerRelationProjectLeads", "MemberId");
            AddForeignKey("dbo.BuyerRelationProjectLeads", "MemberId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.BuyerRelationProjectLeads", "BuyerId", "dbo.Buyer_Detail", "BuyerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuyerRelationProjectLeads", "BuyerId", "dbo.Buyer_Detail");
            DropForeignKey("dbo.BuyerRelationProjectLeads", "MemberId", "dbo.AspNetUsers");
            DropIndex("dbo.BuyerRelationProjectLeads", new[] { "MemberId" });
            DropColumn("dbo.BuyerRelationProjectLeads", "MemberId");
            AddForeignKey("dbo.BuyerRelationProjectLeads", "BuyerId", "dbo.BuyerRelationProjectLeads", "Id");
        }
    }
}
