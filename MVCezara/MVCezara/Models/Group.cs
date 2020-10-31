using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCezara.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<GroupMessage> GroupMessages { get; set; }
    }
}