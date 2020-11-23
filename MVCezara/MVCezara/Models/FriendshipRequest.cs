using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCezara.Models
{
    public class FriendshipRequest
    {
        [Key]
        public int FriendshipRequestId { get; set; }
        //[Key]
        //[Column(Order = 0)]
        [ForeignKey("Requester")]
        public int RequesterId { get; set; }

        //[Key]
        //[Column(Order = 1)]
        [ForeignKey("Receiver")]
        public int? ReceiverId { get; set; }

        public string Message { get; set; }
        public bool IsSeen { get; set; }
        public bool IsAccepted { get; set; }

        public virtual UserPlaceholder Requester { get; set; }
        public virtual UserPlaceholder Receiver { get; set; }
    }
}