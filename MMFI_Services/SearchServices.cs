using MMFI_Entites.Models;
using MMFI_IServices;
using MMFoodIdea.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMFI_Services
{
    public class SearchServices : ISearchServices
    {
        private readonly ApplicationDbContext _appDb;

        public SearchServices(ApplicationDbContext appDb)
        {
            _appDb = appDb;
        }
          
        public List<Recipe> searchLatest(string recipeName, Category category, int? time, int? rating)
        {
            var latestRecipes = _appDb.Recipes.Where(r => r.PostedOn > DateTime.Now.AddDays(-50)).ToList();

            if(time == null)
                time = 999;

            if (rating == null)
                rating = 0;

            if (recipeName == null)
                recipeName = "";

            List<Recipe> recipes;

            if (category != Category.Undefined)
            {
                var filteredRecipes = from recipe in latestRecipes
                                      where recipe.RecipeTime < time && recipe.RecipeCategory == category && recipe.Rating >= rating && recipe.RecipeName.ToLower().Contains(recipeName.ToLower())
                                      orderby recipe.PostedOn descending
                                      select recipe;
                recipes = filteredRecipes.ToList();                               
            }
            else
            {
                var filteredRecipes = from recipe in latestRecipes
                                      where recipe.RecipeTime < time && recipe.Rating >= rating && recipe.RecipeName.ToLower().Contains(recipeName.ToLower())
                                      orderby recipe.PostedOn descending
                                      select recipe;
                recipes = filteredRecipes.ToList();
            }
            
            return recipes;
        }   

        public List<Recipe> searchLiked(string recipeName, Category category, int? time, int? rating,AppUser user)
        {
            var recipeLikes = _appDb.RecipeLikes.Where(r => r.UserId == user.Id);
            var Ids = from rl in recipeLikes select rl.RecipeId;
            var likedRecipes = _appDb.Recipes.Where(r => Ids.Contains(r.RecipeId)).ToList();

            if (time == null)
                time = 999;

            if (rating == null)
                rating = 0;

            if (recipeName == null)
                recipeName = "";

            List<Recipe> recipes;

            if (category != Category.Undefined)
            {
                var filteredRecipes = from recipe in likedRecipes
                                      where recipe.RecipeTime < time && recipe.RecipeCategory == category && recipe.Rating >= rating && recipe.RecipeName.ToLower().Contains(recipeName.ToLower())
                                      orderby recipe.PostedOn descending
                                      select recipe;
                recipes = filteredRecipes.ToList();
            }
            else
            {
                var filteredRecipes = from recipe in likedRecipes
                                      where recipe.RecipeTime < time && recipe.Rating >= rating && recipe.RecipeName.ToLower().Contains(recipeName.ToLower())
                                      orderby recipe.PostedOn descending
                                      select recipe;
                recipes = filteredRecipes.ToList();
            }

            return recipes;
        }

        public List<Recipe> searchPopular(string recipeName, Category category, int? time, int? rating)
        {
            var popularRecipes = _appDb.Recipes.OrderByDescending(r => r.Likes).Where(r => r.Likes > 3).ToList();

            if (time == null)
                time = 999;

            if (rating == null)
                rating = 0;

            if (recipeName == null)
                recipeName = "";

            List<Recipe> recipes;

            if (category != Category.Undefined)
            {
                var filteredRecipes = from recipe in popularRecipes
                                      where recipe.RecipeTime < time && recipe.RecipeCategory == category && recipe.Rating >= rating && recipe.RecipeName.ToLower().Contains(recipeName.ToLower())
                                      orderby recipe.PostedOn descending
                                      select recipe;
                recipes = filteredRecipes.ToList();
            }
            else
            {
                var filteredRecipes = from recipe in popularRecipes
                                      where recipe.RecipeTime < time && recipe.Rating >= rating && recipe.RecipeName.ToLower().Contains(recipeName.ToLower())
                                      orderby recipe.PostedOn descending
                                      select recipe;
                recipes = filteredRecipes.ToList();
            }

            return recipes;
        }
    }
}
