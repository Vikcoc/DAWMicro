namespace MVCezara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        UserPlaceholderId = c.Int(nullable: false),
                        Content = c.String(),
                        IdEdited = c.Boolean(nullable: false),
                        UserPlaceholder_UserPlaceholderId = c.Int(),
                        UserPlaceholder_UserPlaceholderId1 = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.UserPlaceholders", t => t.UserPlaceholder_UserPlaceholderId)
                .ForeignKey("dbo.UserPlaceholders", t => t.UserPlaceholder_UserPlaceholderId1)
                .Index(t => t.PostId)
                .Index(t => t.UserPlaceholder_UserPlaceholderId)
                .Index(t => t.UserPlaceholder_UserPlaceholderId1);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        UserPlaceholderId = c.Int(nullable: false),
                        Content = c.String(),
                        IsEdited = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.UserPlaceholders", t => t.UserPlaceholderId, cascadeDelete: true)
                .Index(t => t.UserPlaceholderId);
            
            CreateTable(
                "dbo.UserPlaceholders",
                c => new
                    {
                        UserPlaceholderId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        IsPublic = c.Boolean(nullable: false),
                        Bio = c.String(),
                    })
                .PrimaryKey(t => t.UserPlaceholderId);
            
            CreateTable(
                "dbo.GroupMessages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        UserPlaceholderId = c.Int(nullable: false),
                        Message = c.String(),
                        IsEdited = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.UserPlaceholders", t => t.UserPlaceholderId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.UserPlaceholderId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        UserPlaceholderId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserPlaceholderId, t.GroupId })
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.UserPlaceholders", t => t.UserPlaceholderId, cascadeDelete: true)
                .Index(t => t.UserPlaceholderId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Notices",
                c => new
                    {
                        NoticeId = c.Int(nullable: false, identity: true),
                        UserPlaceholderId = c.Int(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.NoticeId)
                .ForeignKey("dbo.UserPlaceholders", t => t.UserPlaceholderId, cascadeDelete: true)
                .Index(t => t.UserPlaceholderId);
            
            CreateTable(
                "dbo.FriendshipRequests",
                c => new
                    {
                        FriendshipRequestId = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        IsSeen = c.Boolean(nullable: false),
                        IsAccepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FriendshipRequestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserPlaceholder_UserPlaceholderId1", "dbo.UserPlaceholders");
            DropForeignKey("dbo.Posts", "UserPlaceholderId", "dbo.UserPlaceholders");
            DropForeignKey("dbo.Notices", "UserPlaceholderId", "dbo.UserPlaceholders");
            DropForeignKey("dbo.GroupMessages", "UserPlaceholderId", "dbo.UserPlaceholders");
            DropForeignKey("dbo.UserGroups", "UserPlaceholderId", "dbo.UserPlaceholders");
            DropForeignKey("dbo.UserGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.GroupMessages", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Comments", "UserPlaceholder_UserPlaceholderId", "dbo.UserPlaceholders");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.Notices", new[] { "UserPlaceholderId" });
            DropIndex("dbo.UserGroups", new[] { "GroupId" });
            DropIndex("dbo.UserGroups", new[] { "UserPlaceholderId" });
            DropIndex("dbo.GroupMessages", new[] { "UserPlaceholderId" });
            DropIndex("dbo.GroupMessages", new[] { "GroupId" });
            DropIndex("dbo.Posts", new[] { "UserPlaceholderId" });
            DropIndex("dbo.Comments", new[] { "UserPlaceholder_UserPlaceholderId1" });
            DropIndex("dbo.Comments", new[] { "UserPlaceholder_UserPlaceholderId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropTable("dbo.FriendshipRequests");
            DropTable("dbo.Notices");
            DropTable("dbo.UserGroups");
            DropTable("dbo.Groups");
            DropTable("dbo.GroupMessages");
            DropTable("dbo.UserPlaceholders");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
