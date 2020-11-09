namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumnFileUpload : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileUploadDetails", "PassportCopy", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "DrivingLicenceWithDob", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "VotersId", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "ElectricityBill", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "TelephoneBill", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "LeaveLicenceAggrCopy", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "CompanyAccoLetter", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "OtherBankStatmnt", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "TelephoneProof", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "AadharCardCopy", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "ApplicationFormImaging", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "Form16", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "AppointmentLetter", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "SalarySlip", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "BankStatementLatestSixMonths", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "BankStatmentThreeMonths", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "BankStatementYear", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "VotersIdCard", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "ProfileDocumentDetails", c => c.String());
            AddColumn("dbo.FileUploadDetails", "PanCardId", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "ProfilePhoto", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "ProfileDocumentPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FileUploadDetails", "ProfileDocumentPath");
            DropColumn("dbo.FileUploadDetails", "ProfilePhoto");
            DropColumn("dbo.FileUploadDetails", "PanCardId");
            DropColumn("dbo.FileUploadDetails", "ProfileDocumentDetails");
            DropColumn("dbo.FileUploadDetails", "VotersIdCard");
            DropColumn("dbo.FileUploadDetails", "BankStatementYear");
            DropColumn("dbo.FileUploadDetails", "BankStatmentThreeMonths");
            DropColumn("dbo.FileUploadDetails", "BankStatementLatestSixMonths");
            DropColumn("dbo.FileUploadDetails", "SalarySlip");
            DropColumn("dbo.FileUploadDetails", "AppointmentLetter");
            DropColumn("dbo.FileUploadDetails", "Form16");
            DropColumn("dbo.FileUploadDetails", "ApplicationFormImaging");
            DropColumn("dbo.FileUploadDetails", "AadharCardCopy");
            DropColumn("dbo.FileUploadDetails", "TelephoneProof");
            DropColumn("dbo.FileUploadDetails", "OtherBankStatmnt");
            DropColumn("dbo.FileUploadDetails", "CompanyAccoLetter");
            DropColumn("dbo.FileUploadDetails", "LeaveLicenceAggrCopy");
            DropColumn("dbo.FileUploadDetails", "TelephoneBill");
            DropColumn("dbo.FileUploadDetails", "ElectricityBill");
            DropColumn("dbo.FileUploadDetails", "VotersId");
            DropColumn("dbo.FileUploadDetails", "DrivingLicenceWithDob");
            DropColumn("dbo.FileUploadDetails", "PassportCopy");
        }
    }
}
