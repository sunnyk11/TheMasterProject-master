namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DealerLeadRelationForeignKey : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DealerToLeadRelations", "AssignedManager", c => c.String(maxLength: 128));
            CreateIndex("dbo.DealerToLeadRelations", "AssignedManager");
            AddForeignKey("dbo.DealerToLeadRelations", "AssignedManager", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DealerToLeadRelations", "AssignedManager", "dbo.AspNetUsers");
            DropIndex("dbo.DealerToLeadRelations", new[] { "AssignedManager" });
            AlterColumn("dbo.DealerToLeadRelations", "AssignedManager", c => c.String());
        }
    }
}
