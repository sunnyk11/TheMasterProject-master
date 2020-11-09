namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCityForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "StateCode", "dbo.States");
            DropIndex("dbo.Cities", new[] { "StateCode" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Cities", "StateCode");
            AddForeignKey("dbo.Cities", "StateCode", "dbo.States", "Id", cascadeDelete: true);
        }
    }
}
