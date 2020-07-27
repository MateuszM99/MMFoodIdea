using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MMFI_Entites.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public int RecipeTime { get; set; }
        public List<Ingridient> Ingridients { get; set; }
        public string UserId { get; set; }
        public virtual AppUser Sender { get; set; }
        
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
