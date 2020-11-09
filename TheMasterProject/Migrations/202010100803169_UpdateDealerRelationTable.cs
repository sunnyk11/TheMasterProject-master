namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDealerRelationTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DealerToManagerRelations", "BuyerId", c => c.Int(nullable: false));
            CreateIndex("dbo.DealerToManagerRelations", "BuyerId");
            AddForeignKey("dbo.DealerToManagerRelations", "BuyerId", "dbo.Buyer_Detail", "BuyerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DealerToManagerRelations", "BuyerId", "dbo.Buyer_Detail");
            DropIndex("dbo.DealerToManagerRelations", new[] { "BuyerId" });
            DropColumn("dbo.DealerToManagerRelations", "BuyerId");
        }
    }
}
