﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCezara.Models
{
    public class UserPlaceholder
    {
        [Key] public int UserPlaceholderId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsPublic { get; set; }
        public string Bio { get; set; }

        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<GroupMessage> GroupMessages { get; set; }
        public virtual ICollection<Notice> Notices { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<FriendshipRequest> Requested { get; set; }
        public virtual ICollection<FriendshipRequest> Received { get; set; }
    }
}