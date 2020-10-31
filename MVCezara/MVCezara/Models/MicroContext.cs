﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCezara.Models
{
    public class MicroContext : DbContext
    {
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<FriendshipRequest> FriendshipRequests { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupMessage> GroupMessages { get; set; }
        public virtual DbSet<MicroContext> MicroContexts { get; set; }
        public virtual DbSet<Notice> Notices { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<UserPlaceholder> UserPlaceholders { get; set; }

        public MicroContext() : base("DBConnectionString") { }


    }
}