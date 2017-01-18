namespace PhotoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCountryandStateEntities3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.States", "Country_CountryId", "dbo.Countries");
            DropIndex("dbo.States", new[] { "Country_CountryId" });
            RenameColumn(table: "dbo.States", name: "Country_CountryId", newName: "CountryId");
            AlterColumn("dbo.States", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.States", "CountryId");
            AddForeignKey("dbo.States", "CountryId", "dbo.Countries", "CountryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropIndex("dbo.States", new[] { "CountryId" });
            AlterColumn("dbo.States", "CountryId", c => c.Int());
            RenameColumn(table: "dbo.States", name: "CountryId", newName: "Country_CountryId");
            CreateIndex("dbo.States", "Country_CountryId");
            AddForeignKey("dbo.States", "Country_CountryId", "dbo.Countries", "CountryId");
        }
    }
}
