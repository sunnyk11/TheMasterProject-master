namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class City_State : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateCode = c.Int(nullable: false),
                        CityCode = c.Int(nullable: false),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateCode, cascadeDelete: true)
                .Index(t => t.StateCode);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateCode = c.Int(nullable: false),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "StateCode", "dbo.States");
            DropIndex("dbo.Cities", new[] { "StateCode" });
            DropTable("dbo.States");
            DropTable("dbo.Cities");
        }
    }
}
