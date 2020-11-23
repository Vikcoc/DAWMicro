namespace MVCezara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validari : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Content", c => c.String());
            AlterColumn("dbo.Comments", "Content", c => c.String());
        }
    }
}
