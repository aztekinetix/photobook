namespace PhotoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingIndexToPublisherPicsforImageUrl : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PublisherPics", "IX_PublisherPic_ImageUrl");
            AlterColumn("dbo.PublisherPics", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PublisherPics", "ImageUrl", c => c.String(maxLength: 50));
            CreateIndex("dbo.PublisherPics", "ImageUrl", unique: true, name: "IX_PublisherPic_ImageUrl");
        }
    }
}
