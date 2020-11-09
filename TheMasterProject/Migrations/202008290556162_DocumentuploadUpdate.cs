namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentuploadUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DocumentUploadeds", "BuyerId");
            DropColumn("dbo.DocumentUploadeds", "FileName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DocumentUploadeds", "FileName", c => c.String());
            AddColumn("dbo.DocumentUploadeds", "BuyerId", c => c.Int(nullable: false));
        }
    }
}
