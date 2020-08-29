using System;
using System.Collections.Generic;
using System.Text;

namespace MMFI_Entites.Models
{
    public class Rating
    {        
        public int Rate { get; set; }

        public string UserId { get; set; }

        public int RecipeId { get; set; }
    }
}
