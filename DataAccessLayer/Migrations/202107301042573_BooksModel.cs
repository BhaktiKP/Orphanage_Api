namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BooksModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        Description = c.String(),
                        DonationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}
