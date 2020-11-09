namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuyerDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buyer_Detail",
                c => new
                    {
                        BuyerId = c.Int(nullable: false, identity: true),
                        BuyerName = c.String(),
                        Gender = c.Boolean(nullable: false),
                        MaritalStatus = c.Boolean(nullable: false),
                        EmploymentStatus = c.String(),
                        AadharCard = c.String(),
                        PanCard = c.String(),
                        GrossAnnualIncome = c.String(),
                        GrossMonthlyIncome = c.String(),
                        CompanyName = c.String(),
                        Address = c.String(),
                        MobileNo = c.String(),
                        AlreadyLoad = c.Boolean(nullable: false),
                        pincode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BuyerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Buyer_Detail");
        }
    }
}
