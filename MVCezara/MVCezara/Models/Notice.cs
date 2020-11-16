using System.ComponentModel.DataAnnotations;

namespace MVCezara.Models
{
    public class Notice
    {
        [Key] public int NoticeId { get; set; }

        public int UserPlaceholderId { get; set; }
        public string Content { get; set; }

        public virtual UserPlaceholder UserPlaceholder { get; set; }
    }
}