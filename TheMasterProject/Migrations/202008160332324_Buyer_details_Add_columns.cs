namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Buyer_details_Add_columns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyer_Detail", "LoanAmount", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buyer_Detail", "LoanAmount");
        }
    }
}
