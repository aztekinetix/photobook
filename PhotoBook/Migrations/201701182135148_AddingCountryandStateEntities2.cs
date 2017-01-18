namespace PhotoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCountryandStateEntities2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        Country_CountryId = c.Int(),
                    })
                .PrimaryKey(t => t.StateId)
                .ForeignKey("dbo.Countries", t => t.Country_CountryId)
                .Index(t => t.Country_CountryId);
            
            AddColumn("dbo.Publishers", "Country_CountryId", c => c.Int());
            AddColumn("dbo.Publishers", "State_StateId", c => c.Int());
            CreateIndex("dbo.Publishers", "Country_CountryId");
            CreateIndex("dbo.Publishers", "State_StateId");
            AddForeignKey("dbo.Publishers", "Country_CountryId", "dbo.Countries", "CountryId");
            AddForeignKey("dbo.Publishers", "State_StateId", "dbo.States", "StateId");
            DropColumn("dbo.Publishers", "StateId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Publishers", "StateId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Publishers", "State_StateId", "dbo.States");
            DropForeignKey("dbo.States", "Country_CountryId", "dbo.Countries");
            DropForeignKey("dbo.Publishers", "Country_CountryId", "dbo.Countries");
            DropIndex("dbo.States", new[] { "Country_CountryId" });
            DropIndex("dbo.Publishers", new[] { "State_StateId" });
            DropIndex("dbo.Publishers", new[] { "Country_CountryId" });
            DropColumn("dbo.Publishers", "State_StateId");
            DropColumn("dbo.Publishers", "Country_CountryId");
            DropTable("dbo.States");
            DropTable("dbo.Countries");
        }
    }
}
