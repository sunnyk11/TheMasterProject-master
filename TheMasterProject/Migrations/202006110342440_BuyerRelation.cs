namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuyerRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuyerRelationProjectLeads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectLeadId = c.String(maxLength: 128),
                        BuyerId = c.Int(nullable: false),
                        EmployeeId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BuyerRelationProjectLeads", t => t.BuyerId)
                .ForeignKey("dbo.AspNetUsers", t => t.ProjectLeadId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeId)
                .Index(t => t.ProjectLeadId)
                .Index(t => t.BuyerId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuyerRelationProjectLeads", "EmployeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BuyerRelationProjectLeads", "ProjectLeadId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BuyerRelationProjectLeads", "BuyerId", "dbo.BuyerRelationProjectLeads");
            DropIndex("dbo.BuyerRelationProjectLeads", new[] { "EmployeeId" });
            DropIndex("dbo.BuyerRelationProjectLeads", new[] { "BuyerId" });
            DropIndex("dbo.BuyerRelationProjectLeads", new[] { "ProjectLeadId" });
            DropTable("dbo.BuyerRelationProjectLeads");
        }
    }
}
