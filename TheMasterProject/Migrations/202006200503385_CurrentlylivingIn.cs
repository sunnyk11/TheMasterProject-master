namespace TheMasterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurrentlylivingIn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyer_Detail", "currentlyLivingIn", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buyer_Detail", "currentlyLivingIn");
        }
    }
}
