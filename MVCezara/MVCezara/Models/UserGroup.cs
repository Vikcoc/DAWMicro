using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCezara.Models
{
    public class UserGroup
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }
        [Key, Column(Order = 1)]
        public int GroupId { get; set; }

        public virtual UserPlaceholder UserPlaceholder { get; set; }
        public virtual Group Group { get; set; }
    }
}