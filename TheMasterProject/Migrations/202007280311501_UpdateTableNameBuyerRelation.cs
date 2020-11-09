namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableNameBuyerRelation : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BuyerRelationProjectLeads", newName: "BuyerRelations");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.BuyerRelations", newName: "BuyerRelationProjectLeads");
        }
    }
}
