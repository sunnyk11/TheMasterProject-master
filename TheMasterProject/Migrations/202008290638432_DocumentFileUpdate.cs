namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentFileUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DocumentUploadeds", "FileUploadDetails_Id", "dbo.FileUploadDetails");
            DropIndex("dbo.DocumentUploadeds", new[] { "FileUploadDetails_Id" });
            DropColumn("dbo.DocumentUploadeds", "FileUploadDetails_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DocumentUploadeds", "FileUploadDetails_Id", c => c.Int());
            CreateIndex("dbo.DocumentUploadeds", "FileUploadDetails_Id");
            AddForeignKey("dbo.DocumentUploadeds", "FileUploadDetails_Id", "dbo.FileUploadDetails", "Id");
        }
    }
}
