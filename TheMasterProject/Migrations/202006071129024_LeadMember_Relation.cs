namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeadMember_Relation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lead_Member_Relation",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ProjectLeadId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.ProjectLeadId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ProjectLeadId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lead_Member_Relation", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Lead_Member_Relation", "ProjectLeadId", "dbo.AspNetUsers");
            DropIndex("dbo.Lead_Member_Relation", new[] { "ProjectLeadId" });
            DropIndex("dbo.Lead_Member_Relation", new[] { "UserId" });
            DropTable("dbo.Lead_Member_Relation");
        }
    }
}
