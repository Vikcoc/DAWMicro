using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCezara.Models
{
    public class FriendshipRequest
    {
        [Key,Column(Order = 0)]
        public int RequesterId { get; set; }
        public int ReciverId { get; set; }
        public string Message { get; set; }
        public bool IsSeen { get; set; }
        public bool IsAccepted { get; set; }

        public virtual UserPlaceholder Requester { get; set; }
        public virtual UserPlaceholder Reciver { get; set; }
    }
}