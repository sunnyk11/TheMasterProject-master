namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewFoeignkeyDealerDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DealerToLeadRelations", "LeadCreatedBy", c => c.String());
            AddColumn("dbo.DealerToLeadRelations", "DealerDetails_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.DealerToLeadRelations", "DealerDetails_Id");
            AddForeignKey("dbo.DealerToLeadRelations", "DealerDetails_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DealerToLeadRelations", "DealerDetails_Id", "dbo.AspNetUsers");
            DropIndex("dbo.DealerToLeadRelations", new[] { "DealerDetails_Id" });
            DropColumn("dbo.DealerToLeadRelations", "DealerDetails_Id");
            DropColumn("dbo.DealerToLeadRelations", "LeadCreatedBy");
        }
    }
}
