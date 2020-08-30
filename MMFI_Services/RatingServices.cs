using MMFI_Entites.Models;
using MMFI_IServices;
using MMFoodIdea.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task Rate(Rating rating,AppUser user)
        {

            var lastRate = _appDb.Ratings.Where(r => r.RecipeId == rating.RecipeId && r.UserId == user.Id).FirstOrDefault();
            

            // If is rated then remove the recent rating and add new rating
            if (lastRate != null)
            {
                
                _appDb.Ratings.Remove(lastRate);
                _appDb.Ratings.Add(rating);
                await _appDb.SaveChangesAsync();
            } else
            {               
                _appDb.Ratings.Add(rating);
                await _appDb.SaveChangesAsync();
            }

        }
    }
}
