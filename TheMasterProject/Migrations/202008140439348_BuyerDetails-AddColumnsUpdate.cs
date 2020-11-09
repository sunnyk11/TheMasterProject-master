namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuyerDetailsAddColumnsUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyer_Detail", "Ownership", c => c.String());
            AddColumn("dbo.Buyer_Detail", "LivingSince", c => c.String());
            AddColumn("dbo.Buyer_Detail", "LivingInCitySince", c => c.String());
            AddColumn("dbo.Buyer_Detail", "Address2", c => c.String());
            AddColumn("dbo.Buyer_Detail", "City", c => c.String());
            AddColumn("dbo.Buyer_Detail", "State", c => c.String());
            AddColumn("dbo.Buyer_Detail", "SalaryCreditType", c => c.String());
            AddColumn("dbo.Buyer_Detail", "JoiningYearandMonth", c => c.String());
            AddColumn("dbo.Buyer_Detail", "MonthlySalary", c => c.String());
            AddColumn("dbo.Buyer_Detail", "ConstitutionOfCompany", c => c.String());
            AddColumn("dbo.Buyer_Detail", "officeAddressLine", c => c.String());
            AddColumn("dbo.Buyer_Detail", "officeAddressLine2", c => c.String());
            AddColumn("dbo.Buyer_Detail", "OfficeCity", c => c.String());
            AddColumn("dbo.Buyer_Detail", "OfficeState", c => c.String());
            AddColumn("dbo.Buyer_Detail", "Officepincode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buyer_Detail", "Officepincode");
            DropColumn("dbo.Buyer_Detail", "OfficeState");
            DropColumn("dbo.Buyer_Detail", "OfficeCity");
            DropColumn("dbo.Buyer_Detail", "officeAddressLine2");
            DropColumn("dbo.Buyer_Detail", "officeAddressLine");
            DropColumn("dbo.Buyer_Detail", "ConstitutionOfCompany");
            DropColumn("dbo.Buyer_Detail", "MonthlySalary");
            DropColumn("dbo.Buyer_Detail", "JoiningYearandMonth");
            DropColumn("dbo.Buyer_Detail", "SalaryCreditType");
            DropColumn("dbo.Buyer_Detail", "State");
            DropColumn("dbo.Buyer_Detail", "City");
            DropColumn("dbo.Buyer_Detail", "Address2");
            DropColumn("dbo.Buyer_Detail", "LivingInCitySince");
            DropColumn("dbo.Buyer_Detail", "LivingSince");
            DropColumn("dbo.Buyer_Detail", "Ownership");
        }
    }
}
