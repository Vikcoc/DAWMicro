using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MVCezara.Migrations;

namespace MVCezara.Models
{
    public class MicroContext : DbContext
    {
        public MicroContext() : base("DBConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MicroContext,
            MVCezara.Migrations.Configuration>("DBConnectionString"));
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<FriendshipRequest> FriendshipRequests { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupMessage> GroupMessages { get; set; }
        public virtual DbSet<Notice> Notices { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<UserPlaceholder> UserPlaceholders { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
       // {
         //   modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //}
    }
}