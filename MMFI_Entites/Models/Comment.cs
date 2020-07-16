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
    
        [Column(TypeName = "ntext")]
        public string Body { get; set; }

        public DateTime Date { get; set; }

        public int RecipeId { get; set; }
    }
}
