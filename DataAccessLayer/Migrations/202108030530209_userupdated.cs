namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserType", c => c.String());
            AddColumn("dbo.Users", "Flag", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Flag");
            DropColumn("dbo.Users", "UserType");
        }
    }
}
