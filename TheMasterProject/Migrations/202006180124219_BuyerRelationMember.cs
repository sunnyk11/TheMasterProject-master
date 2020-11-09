namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuyerRelationMember : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuyerRelationMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.String(maxLength: 128),
                        BuyerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BuyerRelationProjectLeads", t => t.BuyerId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.MemberId)
                .Index(t => t.MemberId)
                .Index(t => t.BuyerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuyerRelationMembers", "MemberId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BuyerRelationMembers", "BuyerId", "dbo.BuyerRelationProjectLeads");
            DropIndex("dbo.BuyerRelationMembers", new[] { "BuyerId" });
            DropIndex("dbo.BuyerRelationMembers", new[] { "MemberId" });
            DropTable("dbo.BuyerRelationMembers");
        }
    }
}
