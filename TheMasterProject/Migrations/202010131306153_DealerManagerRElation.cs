namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DealerManagerRElation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DealerToManagerRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DealerId = c.String(maxLength: 128),
                        ManagerId = c.String(maxLength: 128),
                        BuyerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buyer_Detail", t => t.BuyerId)
                .ForeignKey("dbo.AspNetUsers", t => t.DealerId)
                .ForeignKey("dbo.AspNetUsers", t => t.ManagerId)
                .Index(t => t.DealerId)
                .Index(t => t.ManagerId)
                .Index(t => t.BuyerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DealerToManagerRelations", "ManagerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DealerToManagerRelations", "DealerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DealerToManagerRelations", "BuyerId", "dbo.Buyer_Detail");
            DropIndex("dbo.DealerToManagerRelations", new[] { "BuyerId" });
            DropIndex("dbo.DealerToManagerRelations", new[] { "ManagerId" });
            DropIndex("dbo.DealerToManagerRelations", new[] { "DealerId" });
            DropTable("dbo.DealerToManagerRelations");
        }
    }
}
