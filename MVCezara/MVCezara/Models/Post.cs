using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCezara.Models
{
    public class Post
    {
        [Key] public int PostId { get; set; }

        [ForeignKey("UserPlaceholder")] public int UserPlaceholderId { get; set; }

        public string Content { get; set; }
        public bool IsEdited { get; set; }

        public virtual UserPlaceholder UserPlaceholder { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}