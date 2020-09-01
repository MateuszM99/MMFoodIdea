using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MMFI_Entites.Models;
using MMFI_Entites.ViewModels;
using MMFI_IServices;
using MMFoodIdea.Data;

namespace MMFoodIdea.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _appDb;
        private readonly IUploadServices _uploadServices;
        private readonly IUserServices _userServices;

        public UsersController(UserManager<AppUser> userManager, ApplicationDbContext appDb,IUploadServices uploadServices, IUserServices userServices)
        {
            _appDb = appDb;
            _userManager = userManager;
            _uploadServices = uploadServices;
            _userServices = userServices;
        }
       
        [Authorize]
        public async Task<IActionResult> AddProfilePic(IFormFile imageFile)
        {
            var user = await _userManager.GetUserAsync(User);
            await _uploadServices.UploadingProfilePhoto(imageFile, user);
       
            return RedirectToAction("GetUserProfile");
        }

        [Authorize]
        public async Task<IActionResult> GetUserProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            var profileVM = new UserVM();
            profileVM.ProfileImage = _userServices.GetUserProfileImage(user.Id);

            if(profileVM.ProfileImage == null)
            {
                profileVM.ProfileImage = new MMFI_Entites.Models.Image();
                profileVM.ProfileImage.ImagePath = "/images/Default/default-image.png";
                profileVM.ProfileImage.UserId = user.Id;
            }
            
            profileVM.Recipes = _userServices.GetUsersRecipes(user.Id);
            profileVM.LikedRecipes = _userServices.GetUserLikedRecipes(user.Id);
            profileVM.Followers = _userServices.GetUsersFollowers(user.Id);
            profileVM.Rating = _userServices.GetUserRating(user.Id);
            profileVM.UserName = user.UserName;
            profileVM.Description = "hello";

            return View("UsersProfile",profileVM);
        }

        public async Task<IActionResult> GetOUserProfile(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if( user == await _userManager.GetUserAsync(User))
            {
                return RedirectToAction("GetUserProfile");
            }

            var profileVM = new UserVM();
            profileVM.ProfileImage = _userServices.GetUserProfileImage(user.Id);

            if(profileVM.ProfileImage == null)
            {
                profileVM.ProfileImage = new MMFI_Entites.Models.Image();
                profileVM.ProfileImage.ImagePath = "/images/Default/default-image.png";
                profileVM.ProfileImage.UserId = user.Id;
            }
            
            profileVM.Recipes = _userServices.GetUsersRecipes(user.Id);
            profileVM.Followers = _userServices.GetUsersFollowers(user.Id);
            profileVM.Rating = _userServices.GetUserRating(user.Id);
            profileVM.UserName = user.UserName;
            profileVM.Description = "hello";

            return View("OUserProfile", profileVM);
        }

        [Authorize]
        public async Task<IActionResult> LikeRecipe(int recipeId)
        {
            var user = await _userManager.GetUserAsync(User);
            RecipeLike recipeLike = new RecipeLike();
            recipeLike.UserId = user.Id;
            recipeLike.RecipeId = recipeId;
            
            await _appDb.AddAsync(recipeLike);
            await _appDb.SaveChangesAsync();

            return Ok();
        }
    }
}