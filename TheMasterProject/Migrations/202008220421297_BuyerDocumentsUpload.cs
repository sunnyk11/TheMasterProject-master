namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuyerDocumentsUpload : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileUploadDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuyerId = c.Int(nullable: false),
                        AddressProofDetails = c.String(),
                        AddressProofFilePath = c.String(),
                        ApplicationFormDetails = c.String(),
                        ApplicationFormFilePath = c.String(),
                        IncomeProofDetails = c.String(),
                        IncomeProofFilePath = c.String(),
                        BankStatementDetails = c.String(),
                        BankStatementFilePath = c.String(),
                        IdentityProofDetails = c.String(),
                        IdentityProofPath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FileUploadDetails");
        }
    }
}
