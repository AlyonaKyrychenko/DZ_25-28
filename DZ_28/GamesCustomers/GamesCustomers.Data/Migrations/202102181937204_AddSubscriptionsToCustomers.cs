namespace GamesCustomers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddSubscriptionsToCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscriptions", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subscriptions", "CustomerId");
            AddForeignKey("dbo.Subscriptions", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Subscriptions", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Subscriptions", new[] { "CustomerId" });
            DropColumn("dbo.Subscriptions", "CustomerId");
        }
    }
}
