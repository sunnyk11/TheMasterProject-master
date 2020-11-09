namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberLeadReation : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TeamLeadRealtionMembers");
        }
    }
}
