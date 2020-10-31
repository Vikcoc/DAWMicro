using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCezara.Models
{
    public class GroupMessage
    {
        public int MessageId { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public bool IsEdited { get; set; }

        public virtual Group Group { get; set; }
        public virtual UserPlaceholder UserPlaceholder { get; set; }
    }
}