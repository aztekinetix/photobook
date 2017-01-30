namespace PhotoBook.Migrations.IdentityContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsernameAdded : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "NickName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "NickName", c => c.String());
        }
    }
}
