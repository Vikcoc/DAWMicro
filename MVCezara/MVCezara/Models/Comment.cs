﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCezara.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int UserPlaceholderId { get; set; }
        public string Content { get; set; }
        public bool IdEdited { get; set; }

        public virtual Post Post { get; set; }
        public virtual UserPlaceholder UserPlaceholder { get; set; }
    }
}