using System.ComponentModel.DataAnnotations;

namespace MVCezara.Models
{
    public class GroupMessage
    {
        [Key] public int MessageId { get; set; }

        public int GroupId { get; set; }
        public int UserPlaceholderId { get; set; }
        public string Message { get; set; }
        public bool IsEdited { get; set; }

        public virtual Group Group { get; set; }
        public virtual UserPlaceholder UserPlaceholder { get; set; }
    }
}