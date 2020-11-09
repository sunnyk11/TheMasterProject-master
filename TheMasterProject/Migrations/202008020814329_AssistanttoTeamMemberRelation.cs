namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssistanttoTeamMemberRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssistantManagerToMemberRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssistantManagerId = c.String(maxLength: 128),
                        TeamMemberId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AssistantManagerId)
                .ForeignKey("dbo.AspNetUsers", t => t.TeamMemberId)
                .Index(t => t.AssistantManagerId)
                .Index(t => t.TeamMemberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssistantManagerToMemberRelations", "TeamMemberId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AssistantManagerToMemberRelations", "AssistantManagerId", "dbo.AspNetUsers");
            DropIndex("dbo.AssistantManagerToMemberRelations", new[] { "TeamMemberId" });
            DropIndex("dbo.AssistantManagerToMemberRelations", new[] { "AssistantManagerId" });
            DropTable("dbo.AssistantManagerToMemberRelations");
        }
    }
}
