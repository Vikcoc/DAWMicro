namespace MVCezara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class friendship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FriendshipRequests", "RequesterId", c => c.Int(nullable: false));
            AddColumn("dbo.FriendshipRequests", "ReceiverId", c => c.Int());
            CreateIndex("dbo.FriendshipRequests", "RequesterId");
            CreateIndex("dbo.FriendshipRequests", "ReceiverId");
            AddForeignKey("dbo.FriendshipRequests", "ReceiverId", "dbo.UserPlaceholders", "UserPlaceholderId");
            AddForeignKey("dbo.FriendshipRequests", "RequesterId", "dbo.UserPlaceholders", "UserPlaceholderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FriendshipRequests", "RequesterId", "dbo.UserPlaceholders");
            DropForeignKey("dbo.FriendshipRequests", "ReceiverId", "dbo.UserPlaceholders");
            DropIndex("dbo.FriendshipRequests", new[] { "ReceiverId" });
            DropIndex("dbo.FriendshipRequests", new[] { "RequesterId" });
            DropColumn("dbo.FriendshipRequests", "ReceiverId");
            DropColumn("dbo.FriendshipRequests", "RequesterId");
        }
    }
}
