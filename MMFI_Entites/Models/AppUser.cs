using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MMFI_Entites.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Recipes = new List<Recipe>();
            Comments = new List<Comment>();
            ProfileImage = new Image();
            ProfileImage.ImagePath = "/images/Default/default-image.png";
        }

        public virtual Image ProfileImage { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }   
        public virtual ICollection<RecipeLike> LikedRecipes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Follow> Followers { get; set; }

       

    }
}
