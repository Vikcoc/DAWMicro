using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCezara.Models
{
    public class UserGroup
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }

        public virtual UserPlaceholder UserPlaceholder { get; set; }
        public virtual Group Group { get; set; }
    }
}