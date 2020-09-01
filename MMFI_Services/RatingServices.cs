using MMFI_Entites.Models;
using MMFI_IServices;
using MMFoodIdea.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MMFI_Services
{
    public class RatingServices : IRatingServices
    {
        private readonly ApplicationDbContext _appDb;

        public RatingServices(ApplicationDbContext appDb)
        {
            _appDb = appDb;
        }

        public double GetRecipeRating(int recipeId)
        {
            var ratings = _appDb.Ratings.Where(r => r.RecipeId == recipeId).ToList();

            double avg = 0;

            foreach(var rating in ratings)
            {
                avg += rating.Rate / (ratings.Count());
            }

            return avg;
        }

        public async Task Rate(Rating rating,AppUser user,int recipeId)
        {
            var lastRate = _appDb.Ratings.Where(r => r.RecipeId == rating.RecipeId && r.UserId == user.Id).FirstOrDefault();
            var recipeRating = GetRecipeRating(recipeId);
            var recipeRatings = _appDb.Ratings.Where(r => r.RecipeId == rating.RecipeId).Count();         
            
            // If is rated then remove the recent rating and add new rating
            if (lastRate != null)
            {
                recipeRating -= lastRate.Rate / recipeRatings;
                recipeRating += rating.Rate / recipeRatings;

                var recipe = new Recipe() { RecipeId = recipeId, Rating = recipeRating };
                _appDb.Recipes.Attach(recipe);
                _appDb.Entry(recipe).Property(x => x.Rating).IsModified = true;

                _appDb.Ratings.Remove(lastRate);
                _appDb.Ratings.Add(rating);
                await _appDb.SaveChangesAsync();
            } else
            {
                // Include the rating that is being added to the ratings count 
                recipeRatings += 1;
                recipeRating += rating.Rate / recipeRatings;

                var recipe = new Recipe() { RecipeId = recipeId, Rating = recipeRating };
                _appDb.Recipes.Attach(recipe);
                _appDb.Entry(recipe).Property(x => x.Rating).IsModified = true;

                _appDb.Ratings.Add(rating);
                await _appDb.SaveChangesAsync();
            }
        }
    }
}
