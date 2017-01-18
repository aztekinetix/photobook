namespace PhotoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedISActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Publishers", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Publishers", "IsActive");
        }
    }
}
