using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCezara.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public bool IsEdited { get; set; }

        public virtual UserPlaceholder UserPlaceholder { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}