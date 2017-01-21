namespace PhotoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingIndexToPublisherPicsforImageUrl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PublisherPics", "ImageUrl", c => c.String(maxLength: 50));
            CreateIndex("dbo.PublisherPics", "ImageUrl", unique: true, name: "IX_PublisherPic_ImageUrl");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PublisherPics", "IX_PublisherPic_ImageUrl");
            AlterColumn("dbo.PublisherPics", "ImageUrl", c => c.String());
        }
    }
}
