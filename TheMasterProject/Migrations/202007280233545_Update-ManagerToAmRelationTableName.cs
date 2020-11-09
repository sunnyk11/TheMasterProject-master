namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateManagerToAmRelationTableName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Buyer_Detail", name: "ProjectLeadAssigned", newName: "ManagerAssigned");
            RenameColumn(table: "dbo.BuyerRelationProjectLeads", name: "ProjectLeadId", newName: "AssistantManagerId");
            RenameIndex(table: "dbo.Buyer_Detail", name: "IX_ProjectLeadAssigned", newName: "IX_ManagerAssigned");
            RenameIndex(table: "dbo.BuyerRelationProjectLeads", name: "IX_ProjectLeadId", newName: "IX_AssistantManagerId");
            CreateTable(
                "dbo.ManagerToAmRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ManagerId = c.String(),
                        AssitantManagerId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.BuyerRelationProjectLeads", "ManagerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BuyerRelationProjectLeads", "ManagerId");
            AddForeignKey("dbo.BuyerRelationProjectLeads", "ManagerId", "dbo.AspNetUsers", "Id");
            DropTable("dbo.TeamLeadRealtionMembers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TeamLeadRealtionMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.String(),
                        TeamLeadId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.BuyerRelationProjectLeads", "ManagerId", "dbo.AspNetUsers");
            DropIndex("dbo.BuyerRelationProjectLeads", new[] { "ManagerId" });
            DropColumn("dbo.BuyerRelationProjectLeads", "ManagerId");
            DropTable("dbo.ManagerToAmRelations");
            RenameIndex(table: "dbo.BuyerRelationProjectLeads", name: "IX_AssistantManagerId", newName: "IX_ProjectLeadId");
            RenameIndex(table: "dbo.Buyer_Detail", name: "IX_ManagerAssigned", newName: "IX_ProjectLeadAssigned");
            RenameColumn(table: "dbo.BuyerRelationProjectLeads", name: "AssistantManagerId", newName: "ProjectLeadId");
            RenameColumn(table: "dbo.Buyer_Detail", name: "ManagerAssigned", newName: "ProjectLeadAssigned");
        }
    }
}
