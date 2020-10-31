using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCezara.Models
{
    public class Notice
    {
        [Key]
        public int NoticeId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }

        public virtual UserPlaceholder UserPlaceholder { get; set; }
    }
}