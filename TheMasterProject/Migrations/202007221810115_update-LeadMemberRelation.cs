namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateLeadMemberRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lead_Member_Relation", "ProjectLeadId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Lead_Member_Relation", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Lead_Member_Relation", new[] { "UserId" });
            DropIndex("dbo.Lead_Member_Relation", new[] { "ProjectLeadId" });
            AlterColumn("dbo.Lead_Member_Relation", "UserId", c => c.String());
            AlterColumn("dbo.Lead_Member_Relation", "ProjectLeadId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lead_Member_Relation", "ProjectLeadId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Lead_Member_Relation", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Lead_Member_Relation", "ProjectLeadId");
            CreateIndex("dbo.Lead_Member_Relation", "UserId");
            AddForeignKey("dbo.Lead_Member_Relation", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Lead_Member_Relation", "ProjectLeadId", "dbo.AspNetUsers", "Id");
        }
    }
}
