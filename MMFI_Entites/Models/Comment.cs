﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMFI_Entites.Models
{
    public class Comment
    {
        public Comment()
        {
            Reactions = new List<CommentLike>();
        }

        [Key]
        public int CommentID { get; set; }
        public string UserName { get; set; }          
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<CommentLike> Reactions { get; set; }
        public string Reacted { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public string UserId { get; set; }
        public virtual AppUser Sender { get; set; }
        public virtual Recipe Recipe { get; set; }
        public int RecipeId { get; set; }
       
    }
}
