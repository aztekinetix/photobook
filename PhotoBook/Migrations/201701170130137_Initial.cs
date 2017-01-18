namespace PhotoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PublisherPics",
                c => new
                    {
                        PublisherPicId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        UploadedOn = c.DateTime(),
                        UploadedByUserId = c.String(),
                        Order = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PublisherPicId)
                .ForeignKey("dbo.Publishers", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PublisherId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IdNumber = c.String(nullable: false),
                        IdImageUrl = c.String(),
                        Address = c.String(nullable: false),
                        StateId = c.Int(nullable: false),
                        Telephone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ProfileImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.PublisherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PublisherPics", "PublisherId", "dbo.Publishers");
            DropIndex("dbo.PublisherPics", new[] { "PublisherId" });
            DropTable("dbo.Publishers");
            DropTable("dbo.PublisherPics");
        }
    }
}
