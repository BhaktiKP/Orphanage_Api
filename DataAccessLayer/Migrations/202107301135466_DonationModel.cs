namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DonationModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        DonationID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        Description = c.String(),
                        DonationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DonationID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Donations");
        }
    }
}
