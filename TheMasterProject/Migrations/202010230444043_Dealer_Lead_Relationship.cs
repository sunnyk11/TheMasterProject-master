namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dealer_Lead_Relationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DealerToLeadRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuyerId = c.Int(nullable: false),
                        PhoneNo = c.String(),
                        AadharCard = c.String(),
                        PanCard = c.String(),
                        WillGetPayout = c.Boolean(nullable: false),
                        BuyerName = c.String(),
                        AssignedManager = c.String(),
                        AssignedAssistantManager = c.String(),
                        AssignedTeamMember = c.String(),
                        LeadCreatedOn = c.DateTime(nullable: false),
                        LeadStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buyer_Detail", t => t.BuyerId, cascadeDelete: true)
                .Index(t => t.BuyerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DealerToLeadRelations", "BuyerId", "dbo.Buyer_Detail");
            DropIndex("dbo.DealerToLeadRelations", new[] { "BuyerId" });
            DropTable("dbo.DealerToLeadRelations");
        }
    }
}
