namespace PhotoBook.Migrations.PhotoBookContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentsModified : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        CreatedOn = c.DateTime(),
                        CreatedByUserName = c.String(),
                        ReplyToCommentId = c.Int(),
                        PublisherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId);
            
            //CreateTable(
            //    "dbo.Countries",
            //    c => new
            //        {
            //            CountryId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            isActive = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.CountryId);
            
            //CreateTable(
            //    "dbo.PublisherPics",
            //    c => new
            //        {
            //            PublisherPicId = c.Int(nullable: false, identity: true),
            //            PublisherId = c.Int(nullable: false),
            //            ImageUrl = c.String(),
            //            UploadedOn = c.DateTime(),
            //            UploadedByUserId = c.String(),
            //            Order = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.PublisherPicId)
            //    .ForeignKey("dbo.Publishers", t => t.PublisherId, cascadeDelete: true)
            //    .Index(t => t.PublisherId);
            
            //CreateTable(
            //    "dbo.Publishers",
            //    c => new
            //        {
            //            PublisherId = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false),
            //            IdNumber = c.String(nullable: false),
            //            IdImageUrl = c.String(),
            //            Address = c.String(nullable: false),
            //            Telephone = c.String(nullable: false),
            //            Email = c.String(nullable: false),
            //            TwitterAccount = c.String(),
            //            Facebook = c.String(),
            //            ProfileImageUrl = c.String(),
            //            PricePerService = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            DescriptionService = c.String(),
            //            IsActive = c.Boolean(nullable: false),
            //            StateId = c.Int(),
            //            CountryId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.PublisherId)
            //    .ForeignKey("dbo.Countries", t => t.CountryId)
            //    .ForeignKey("dbo.States", t => t.StateId)
            //    .Index(t => t.StateId)
            //    .Index(t => t.CountryId);
            
            //CreateTable(
            //    "dbo.States",
            //    c => new
            //        {
            //            StateId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            isActive = c.Boolean(nullable: false),
            //            CountryId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.StateId)
            //    .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
            //    .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Publishers", "StateId", "dbo.States");
            //DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            //DropForeignKey("dbo.PublisherPics", "PublisherId", "dbo.Publishers");
            //DropForeignKey("dbo.Publishers", "CountryId", "dbo.Countries");
            //DropIndex("dbo.States", new[] { "CountryId" });
            //DropIndex("dbo.Publishers", new[] { "CountryId" });
            //DropIndex("dbo.Publishers", new[] { "StateId" });
            //DropIndex("dbo.PublisherPics", new[] { "PublisherId" });
            //DropTable("dbo.States");
            //DropTable("dbo.Publishers");
            //DropTable("dbo.PublisherPics");
            //DropTable("dbo.Countries");
            DropTable("dbo.Comments");
        }
    }
}
