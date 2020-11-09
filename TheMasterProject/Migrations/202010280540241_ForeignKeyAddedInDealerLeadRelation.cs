namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyAddedInDealerLeadRelation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DealerToLeadRelations", "AssignedAssistantManager", c => c.String(maxLength: 128));
            AlterColumn("dbo.DealerToLeadRelations", "AssignedTeamMember", c => c.String(maxLength: 128));
            CreateIndex("dbo.DealerToLeadRelations", "AssignedAssistantManager");
            CreateIndex("dbo.DealerToLeadRelations", "AssignedTeamMember");
            AddForeignKey("dbo.DealerToLeadRelations", "AssignedAssistantManager", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.DealerToLeadRelations", "AssignedTeamMember", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DealerToLeadRelations", "AssignedTeamMember", "dbo.AspNetUsers");
            DropForeignKey("dbo.DealerToLeadRelations", "AssignedAssistantManager", "dbo.AspNetUsers");
            DropIndex("dbo.DealerToLeadRelations", new[] { "AssignedTeamMember" });
            DropIndex("dbo.DealerToLeadRelations", new[] { "AssignedAssistantManager" });
            AlterColumn("dbo.DealerToLeadRelations", "AssignedTeamMember", c => c.String());
            AlterColumn("dbo.DealerToLeadRelations", "AssignedAssistantManager", c => c.String());
        }
    }
}
