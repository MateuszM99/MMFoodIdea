using MMFI_Entites.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MMFI_IServices
{
    public interface IRatingServices
    {
       Task Rate(Rating rating,AppUser user);

       double GetRecipeRating(int recipeId);
    }
}
