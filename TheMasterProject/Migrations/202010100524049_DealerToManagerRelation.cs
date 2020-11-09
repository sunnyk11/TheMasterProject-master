namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DealerToManagerRelation : DbMigration
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.DealerId)
                .ForeignKey("dbo.AspNetUsers", t => t.ManagerId)
                .Index(t => t.DealerId)
                .Index(t => t.ManagerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DealerToManagerRelations", "ManagerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DealerToManagerRelations", "DealerId", "dbo.AspNetUsers");
            DropIndex("dbo.DealerToManagerRelations", new[] { "ManagerId" });
            DropIndex("dbo.DealerToManagerRelations", new[] { "DealerId" });
            DropTable("dbo.DealerToManagerRelations");
        }
    }
}
