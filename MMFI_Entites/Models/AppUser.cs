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
            Images = new List<Image>();
        }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }        
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Follow> Followers { get; set; }

       

    }
}
