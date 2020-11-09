namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFileUpload : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileUploadDetails", "Itr", c => c.Boolean(nullable: false));
            AddColumn("dbo.FileUploadDetails", "GstCertification", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FileUploadDetails", "GstCertification");
            DropColumn("dbo.FileUploadDetails", "Itr");
        }
    }
}
