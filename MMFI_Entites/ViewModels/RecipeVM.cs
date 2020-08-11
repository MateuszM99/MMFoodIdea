using MMFI_Entites.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMFI_Entites.ViewModels
{
    public class RecipeVM
    {
        // public RecipeVM(string RecipeName, int RecipeTime, string RecipeCategory, string RecipePortions, string RecipeInstructions, AppUser Sender, DateTime PostedOn)
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public int RecipeTime { get; set; }
        public string RecipeCategory { get; set; }
        public string RecipePortions { get; set; }
        public string RecipeInstructions { get; set; }
        public List<Ingridient> Ingridients { get; set; }
        public virtual AppUser Sender { get; set; }
        public DateTime PostedOn { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
      
    }
}
