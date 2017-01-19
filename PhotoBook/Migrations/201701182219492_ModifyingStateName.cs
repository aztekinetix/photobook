namespace PhotoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyingStateName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.States", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.States", "Name", c => c.Int(nullable: false));
        }
    }
}
