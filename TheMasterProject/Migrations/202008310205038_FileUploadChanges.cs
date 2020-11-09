namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileUploadChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FileUploadDetails", "AddressDetailId", c => c.Int(nullable: false));
            AlterColumn("dbo.FileUploadDetails", "ApplicationFormDetailId", c => c.Int(nullable: false));
            AlterColumn("dbo.FileUploadDetails", "IncomeProofDetailId", c => c.Int(nullable: false));
            AlterColumn("dbo.FileUploadDetails", "BankStatementDetailId", c => c.Int(nullable: false));
            AlterColumn("dbo.FileUploadDetails", "IdentityProofDetailId", c => c.Int(nullable: false));
            AlterColumn("dbo.FileUploadDetails", "ProfileDocumentDetailId", c => c.Int(nullable: false));
            DropColumn("dbo.FileUploadDetails", "AddressProofFilePath");
            DropColumn("dbo.FileUploadDetails", "ApplicationFormFilePath");
            DropColumn("dbo.FileUploadDetails", "IncomeProofFilePath");
            DropColumn("dbo.FileUploadDetails", "BankStatementFilePath");
            DropColumn("dbo.FileUploadDetails", "IdentityProofPath");
            DropColumn("dbo.FileUploadDetails", "ProfileDocumentPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FileUploadDetails", "ProfileDocumentPath", c => c.String());
            AddColumn("dbo.FileUploadDetails", "IdentityProofPath", c => c.String());
            AddColumn("dbo.FileUploadDetails", "BankStatementFilePath", c => c.String());
            AddColumn("dbo.FileUploadDetails", "IncomeProofFilePath", c => c.String());
            AddColumn("dbo.FileUploadDetails", "ApplicationFormFilePath", c => c.String());
            AddColumn("dbo.FileUploadDetails", "AddressProofFilePath", c => c.String());
            AlterColumn("dbo.FileUploadDetails", "ProfileDocumentDetailId", c => c.String());
            AlterColumn("dbo.FileUploadDetails", "IdentityProofDetailId", c => c.String());
            AlterColumn("dbo.FileUploadDetails", "BankStatementDetailId", c => c.String());
            AlterColumn("dbo.FileUploadDetails", "IncomeProofDetailId", c => c.String());
            AlterColumn("dbo.FileUploadDetails", "ApplicationFormDetailId", c => c.String());
            AlterColumn("dbo.FileUploadDetails", "AddressDetailId", c => c.String());
        }
    }
}
