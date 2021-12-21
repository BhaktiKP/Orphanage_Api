namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manageDonations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ManageDonations",
                c => new
                    {
                        ManageDonationID = c.Int(nullable: false, identity: true),
                        DonationName = c.String(),
                        DonationImage = c.String(),
                        RouterLink = c.String(),
                        Flag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ManageDonationID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ManageDonations");
        }
    }
}
