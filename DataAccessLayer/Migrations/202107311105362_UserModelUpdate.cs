namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donations", "UserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donations", "UserID");
        }
    }
}
