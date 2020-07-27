using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MMFI_Entites.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        public string UserId { get; set; }
        public int RecipeId { get; set; }
        public string ImagePath { get; set; }
    }
}
