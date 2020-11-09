namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuyerDetailsAddColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyer_Detail", "Email", c => c.String());
            AddColumn("dbo.Buyer_Detail", "dob", c => c.String());
            AddColumn("dbo.Buyer_Detail", "FatherFirstName", c => c.String());
            AddColumn("dbo.Buyer_Detail", "FatherMiddleName", c => c.String());
            AddColumn("dbo.Buyer_Detail", "FatherLastName", c => c.String());
            AddColumn("dbo.Buyer_Detail", "MotherFirstName", c => c.String());
            AddColumn("dbo.Buyer_Detail", "MotherMiddleName", c => c.String());
            AddColumn("dbo.Buyer_Detail", "MotherLastName", c => c.String());
            AddColumn("dbo.Buyer_Detail", "PersonalComments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buyer_Detail", "PersonalComments");
            DropColumn("dbo.Buyer_Detail", "MotherLastName");
            DropColumn("dbo.Buyer_Detail", "MotherMiddleName");
            DropColumn("dbo.Buyer_Detail", "MotherFirstName");
            DropColumn("dbo.Buyer_Detail", "FatherLastName");
            DropColumn("dbo.Buyer_Detail", "FatherMiddleName");
            DropColumn("dbo.Buyer_Detail", "FatherFirstName");
            DropColumn("dbo.Buyer_Detail", "dob");
            DropColumn("dbo.Buyer_Detail", "Email");
        }
    }
}
