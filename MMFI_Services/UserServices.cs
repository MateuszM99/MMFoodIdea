﻿using MMFI_Entites.Models;
using MMFI_IServices;
using MMFoodIdea.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace MMFI_Services
{
   
    public class UserServices : IUserServices
    {

        private readonly ApplicationDbContext _appDb;

        public UserServices(ApplicationDbContext appDb)
        {
            _appDb = appDb;
        }
      
        public List<Recipe> GetUserLikedRecipes(string UserId)
        {
            var ids = _appDb.RecipeLikes.Where(r => r.UserId == UserId).Select(r => r.RecipeId);

            return _appDb.Recipes.Where(r => ids.Contains(r.RecipeId)).ToList();
        }

        public Image GetUserProfileImage(string UserId)
        {
            return _appDb.Images.Where(i => i.UserId == UserId).FirstOrDefault();
        }
     
        public List<Recipe> GetUsersRecipes(string UserId)
        {
            return _appDb.Recipes.Where(r => r.UserId == UserId).ToList();
        }
    }
}
