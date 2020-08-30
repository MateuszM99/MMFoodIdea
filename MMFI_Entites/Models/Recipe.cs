using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MMFI_Entites.Models
{
    public class Recipe
    {
        public Recipe()
        {
            Ingridients = new List<Ingridient>();
            Images = new List<Image>();
            Comments = new List<Comment>();
        }

        [Key]
        public int RecipeId { get; set; }

        [Required(ErrorMessage = "Title is required")]          
        public string RecipeName { get; set; }

        [Required(ErrorMessage ="Time is required")]
        public int RecipeTime { get; set; }
       
        [Required(ErrorMessage = "Category is required")]
        public Category RecipeCategory { get; set; }

        [Required(ErrorMessage = "Portions are required")]
        public string RecipePortions { get; set; }

        [Required(ErrorMessage = "Instructions are required")]
        public string RecipeInstructions { get; set; }

        [Required(ErrorMessage = "At least one ingridient is required")]
        public List<Ingridient> Ingridients { get; set; }
     
        public string UserId { get; set; }
        public virtual AppUser Sender { get; set; }        
        public DateTime PostedOn { get; set; }
        
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public int Likes { get; set; }
    }
}
