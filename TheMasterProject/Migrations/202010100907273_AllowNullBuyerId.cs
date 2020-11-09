namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowNullBuyerId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DealerToManagerRelations", "BuyerId", "dbo.Buyer_Detail");
            DropIndex("dbo.DealerToManagerRelations", new[] { "BuyerId" });
            AlterColumn("dbo.DealerToManagerRelations", "BuyerId", c => c.Int());
            CreateIndex("dbo.DealerToManagerRelations", "BuyerId");
            AddForeignKey("dbo.DealerToManagerRelations", "BuyerId", "dbo.Buyer_Detail", "BuyerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DealerToManagerRelations", "BuyerId", "dbo.Buyer_Detail");
            DropIndex("dbo.DealerToManagerRelations", new[] { "BuyerId" });
            AlterColumn("dbo.DealerToManagerRelations", "BuyerId", c => c.Int(nullable: false));
            CreateIndex("dbo.DealerToManagerRelations", "BuyerId");
            AddForeignKey("dbo.DealerToManagerRelations", "BuyerId", "dbo.Buyer_Detail", "BuyerId", cascadeDelete: true);
        }
    }
}
