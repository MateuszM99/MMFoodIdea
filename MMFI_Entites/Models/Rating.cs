using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MMFI_Entites.Models
{
    public class Rating
    {       
        [Key]
        public int RateId { get; set; }

        public int Rate { get; set; }

        public string UserId { get; set; }

        public int RecipeId { get; set; }
    }
}
