using System;
using System.Collections.Generic;
using System.Text;

namespace MMFI_Entites.Models
{
   public class RecipeLike
    {
     public int RecipeLikeId { get; set; }
     public int RecipeId { get; set; }
     public string UserId { get; set; }
    }
}
