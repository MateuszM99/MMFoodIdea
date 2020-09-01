using MMFI_Entites.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMFI_IServices
{
   public interface ISearchServices
    {
        List<Recipe> searchLatest(string recipeName, Category category, int? time, int? rating);

        List<Recipe> searchPopular(string recipeName, Category category, int? time, int? rating);

        List<Recipe> searchLiked(string recipeName, Category category, int? time, int? rating,AppUser user);
    }
}
