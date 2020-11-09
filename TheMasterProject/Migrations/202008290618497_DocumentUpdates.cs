namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileUploadDetails", "AddressDetailId", c => c.String());
            AddColumn("dbo.FileUploadDetails", "ApplicationFormDetailId", c => c.String());
            AddColumn("dbo.FileUploadDetails", "IncomeProofDetailId", c => c.String());
            AddColumn("dbo.FileUploadDetails", "BankStatementDetailId", c => c.String());
            AddColumn("dbo.FileUploadDetails", "IdentityProofDetailId", c => c.String());
            AddColumn("dbo.FileUploadDetails", "ProfileDocumentDetailId", c => c.String());
            AddColumn("dbo.DocumentUploadeds", "BuyerId", c => c.Int(nullable: false));
            AddColumn("dbo.DocumentUploadeds", "FileName", c => c.String());
            AddColumn("dbo.DocumentUploadeds", "FileType", c => c.Int(nullable: false));
            AddColumn("dbo.DocumentUploadeds", "FileUploadDetails_Id", c => c.Int());
            CreateIndex("dbo.DocumentUploadeds", "FileUploadDetails_Id");
            AddForeignKey("dbo.DocumentUploadeds", "FileUploadDetails_Id", "dbo.FileUploadDetails", "Id");
            DropColumn("dbo.FileUploadDetails", "AddressProofDetails");
            DropColumn("dbo.FileUploadDetails", "ApplicationFormDetails");
            DropColumn("dbo.FileUploadDetails", "IncomeProofDetails");
            DropColumn("dbo.FileUploadDetails", "BankStatementDetails");
            DropColumn("dbo.FileUploadDetails", "IdentityProofDetails");
            DropColumn("dbo.FileUploadDetails", "ProfileDocumentDetails");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FileUploadDetails", "ProfileDocumentDetails", c => c.String());
            AddColumn("dbo.FileUploadDetails", "IdentityProofDetails", c => c.String());
            AddColumn("dbo.FileUploadDetails", "BankStatementDetails", c => c.String());
            AddColumn("dbo.FileUploadDetails", "IncomeProofDetails", c => c.String());
            AddColumn("dbo.FileUploadDetails", "ApplicationFormDetails", c => c.String());
            AddColumn("dbo.FileUploadDetails", "AddressProofDetails", c => c.String());
            DropForeignKey("dbo.DocumentUploadeds", "FileUploadDetails_Id", "dbo.FileUploadDetails");
            DropIndex("dbo.DocumentUploadeds", new[] { "FileUploadDetails_Id" });
            DropColumn("dbo.DocumentUploadeds", "FileUploadDetails_Id");
            DropColumn("dbo.DocumentUploadeds", "FileType");
            DropColumn("dbo.DocumentUploadeds", "FileName");
            DropColumn("dbo.DocumentUploadeds", "BuyerId");
            DropColumn("dbo.FileUploadDetails", "ProfileDocumentDetailId");
            DropColumn("dbo.FileUploadDetails", "IdentityProofDetailId");
            DropColumn("dbo.FileUploadDetails", "BankStatementDetailId");
            DropColumn("dbo.FileUploadDetails", "IncomeProofDetailId");
            DropColumn("dbo.FileUploadDetails", "ApplicationFormDetailId");
            DropColumn("dbo.FileUploadDetails", "AddressDetailId");
        }
    }
}
