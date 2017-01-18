namespace PhotoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PublisherMod1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Publishers", "PricePerService", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Publishers", "DescriptionService", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Publishers", "DescriptionService");
            DropColumn("dbo.Publishers", "PricePerService");
        }
    }
}
