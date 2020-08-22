using MMFI_Entites.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMFI_Entites.ViewModels
{
   public class UserVM
    {
        public string UserName { get; set; }
        public string Description { get; set; }
        public Image ProfileImage { get; set; }
        public List<Recipe> Recipes { get; set; }
        public List<Recipe> LikedRecipes { get; set; }
        public List<Follow> Followers { get; set; }
        public double Rating { get; set; }
         
    }
}
