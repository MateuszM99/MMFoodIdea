using MMFI_Entites.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMFI_IServices
{
    public interface IUserServices
    {
        Image GetUserProfileImage(string UserId);
        
        List<Recipe> GetUsersRecipes(string UserId);

        List<Recipe> GetUserLikedRecipes(string UserId);
               
    }
}
