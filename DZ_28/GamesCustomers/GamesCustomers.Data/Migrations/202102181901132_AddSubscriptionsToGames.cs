namespace GamesCustomers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddSubscriptionsToGames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscription", "GameId", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "SubscriptionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subscriptions", "GametId");
            AddForeignKey("dbo.Subscriptions", "GameId", "dbo.Games", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Subscriptions", "GameId", "dbo.Games");
            DropIndex("dbo.Subscriptions", new[] { "GameId" });
            DropColumn("dbo.Games", "SubscriptionId");
            DropColumn("dbo.Subscriptions", "GameId");
        }
    }
}