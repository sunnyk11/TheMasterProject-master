namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyRelationManager : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ManagerToAmRelations", "ManagerId", c => c.String(maxLength: 128));
            AlterColumn("dbo.ManagerToAmRelations", "AssitantManagerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ManagerToAmRelations", "ManagerId");
            CreateIndex("dbo.ManagerToAmRelations", "AssitantManagerId");
            AddForeignKey("dbo.ManagerToAmRelations", "AssitantManagerId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ManagerToAmRelations", "ManagerId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ManagerToAmRelations", "ManagerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ManagerToAmRelations", "AssitantManagerId", "dbo.AspNetUsers");
            DropIndex("dbo.ManagerToAmRelations", new[] { "AssitantManagerId" });
            DropIndex("dbo.ManagerToAmRelations", new[] { "ManagerId" });
            AlterColumn("dbo.ManagerToAmRelations", "AssitantManagerId", c => c.String());
            AlterColumn("dbo.ManagerToAmRelations", "ManagerId", c => c.String());
        }
    }
}
