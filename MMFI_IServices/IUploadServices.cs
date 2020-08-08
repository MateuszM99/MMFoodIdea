using Microsoft.AspNetCore.Http;
using MMFI_Entites.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MMFI_IServices
{
    public interface IUploadServices
    {
         Task UploadingProfilePhoto(IFormFile imageFile,AppUser appUser);

        Task UploadingRecipePhoto(IFormFile imageFile, AppUser appUser, int recipeId);
    }
}
