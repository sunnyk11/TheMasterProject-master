namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delete_BuyerRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BuyerRelationProjectLeads", "EmployeeId", "dbo.AspNetUsers");
            DropIndex("dbo.BuyerRelationProjectLeads", new[] { "EmployeeId" });
            DropColumn("dbo.BuyerRelationProjectLeads", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BuyerRelationProjectLeads", "EmployeeId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BuyerRelationProjectLeads", "EmployeeId");
            AddForeignKey("dbo.BuyerRelationProjectLeads", "EmployeeId", "dbo.AspNetUsers", "Id");
        }
    }
}
