using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MMFI_Entites.Models
{
    public class Recipe
    {
        public Recipe()
        {
            Images = new List<Image>();
        }

        [Key]
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public int RecipeTime { get; set; }
        public string RecipeCategory { get; set; }
        public string RecipePortions { get; set; }
        public string RecipeInstructions { get; set; }
        public IList<RecipeIngridients> RecipeIngridients { get; set; }
        public string UserId { get; set; }
        public virtual AppUser Sender { get; set; }        
        public DateTime PostedOn { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public int Likes { get; set; }
    }
}
