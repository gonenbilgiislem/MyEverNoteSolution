﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEvernote.Entities
{
    [Table("Notes")]
    public class Note : MyEntityBase
    {
        //public Note()
        //{
        //    Comments = new List<Comment>();
        //    Likes = new List<Liked>();
        //}

        [Required] [StringLength(60)] public string Title { get; set; }

        [Required] [StringLength(2000)] public string Text { get; set; }

        public bool IsDraft { get; set; }

        public int LikeCount { get; set; }

        public int CategoryId { get; set; }

        public virtual EvernoteUser Owner { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Liked> Likes { get; set; }
    }
}