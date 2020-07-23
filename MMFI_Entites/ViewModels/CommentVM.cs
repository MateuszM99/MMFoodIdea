using MMFI_Entites.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMFI_Entites.ViewModels
{
    public class CommentVM
    {
        public List<Comment> comments;

        public AppUser User { get; set; }

        public string UserId { get; set; }

        public int RecipeID { get; set; }
    }
}
