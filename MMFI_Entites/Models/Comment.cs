using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMFI_Entites.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string UserName { get; set; }          
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public  int Likes { get; set; }

        // If the comment is reply to another comment then the replyID parameter is given and its value is the id of comment we reply to
        public int? ReplyID { get; set; }

        public string UserId { get; set; }
        public virtual AppUser Sender { get; set; }
        public virtual Recipe Recipe { get; set; }
        public int RecipeId { get; set; }
       
    }
}
