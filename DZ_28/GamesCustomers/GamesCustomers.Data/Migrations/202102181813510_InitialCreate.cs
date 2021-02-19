namespace GamesCustomers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscriptions",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Code = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Games",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    GameName = c.String(),
                    GameKey = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Customers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(),
                    LastName = c.String(),
                    PurchaseId = c.Int(nullable: false),
                    Subscription = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Subscriptions");
            DropTable("dbo.Games");
            DropTable("dbo.Customers");
        }
    }
}