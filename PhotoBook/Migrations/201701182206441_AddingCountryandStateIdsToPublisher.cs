namespace PhotoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCountryandStateIdsToPublisher : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Publishers", name: "Country_CountryId", newName: "CountryId");
            RenameColumn(table: "dbo.Publishers", name: "State_StateId", newName: "StateId");
            RenameIndex(table: "dbo.Publishers", name: "IX_State_StateId", newName: "IX_StateId");
            RenameIndex(table: "dbo.Publishers", name: "IX_Country_CountryId", newName: "IX_CountryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Publishers", name: "IX_CountryId", newName: "IX_Country_CountryId");
            RenameIndex(table: "dbo.Publishers", name: "IX_StateId", newName: "IX_State_StateId");
            RenameColumn(table: "dbo.Publishers", name: "StateId", newName: "State_StateId");
            RenameColumn(table: "dbo.Publishers", name: "CountryId", newName: "Country_CountryId");
        }
    }
}
