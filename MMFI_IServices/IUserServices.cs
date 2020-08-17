using MMFI_Entites.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMFI_IServices
{
    public interface IUserServices
    {
        Image GetUserProfileImage(string UserId);

        Image GetDefaultImage();

        List<Recipe> GetUsersRecipes(string UserId);

        List<Recipe> GetUserLikedRecipes(string UserId);

        List<Follow> GetUsersFollowers(string UserId);

        double GetUserRating(string UserId);
    }
}
