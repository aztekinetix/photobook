namespace PhotoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTwitterandFacebooktoPublisher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Publishers", "TwitterAccount", c => c.String());
            AddColumn("dbo.Publishers", "Facebook", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Publishers", "Facebook");
            DropColumn("dbo.Publishers", "TwitterAccount");
        }
    }
}
