﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MMFI_Data.Data;
using MMFI_Entites.Models;
using MMFI_Entites.ViewModels;
using MMFI_IServices;
using MMFI_Services;
using MMFoodIdea.Data;

namespace MMFoodIdea.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _appDb;
        private readonly ICommentServices _cServices;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUploadServices _uploadServices;
        private readonly IRatingServices _ratingServices;
        private readonly ISearchServices _searchServices;
        public RecipesController(ApplicationDbContext appDb, ICommentServices cServices, UserManager<AppUser> userManager, IUploadServices uploadServices, IRatingServices ratingServices, ISearchServices searchServices)
        {
            _userManager = userManager;
            _appDb = appDb;
            _cServices = cServices;
            _uploadServices = uploadServices;
            _ratingServices = ratingServices;
            _searchServices = searchServices;
        }

        public IActionResult Index()
        {
            return View("StartPage");
        }
  
        public async Task<IActionResult> Select(string sortType,string recipeName,Category category,int? time,int? rating)
        {
            RecipesMainVM mainVM = new RecipesMainVM();
            List<Recipe> recipes = _appDb.Recipes.Where(r => r.RecipeName != null).ToList();           

            switch (sortType)
            {
                case "latest":
                    recipes = _searchServices.searchLatest(recipeName,category,time,rating);                                  
                    break;
                case "popular":                   
                    recipes = _searchServices.searchPopular(recipeName, category, time, rating);
                    break;
                case "liked":
                    var user = await _userManager.GetUserAsync(User);
                    recipes = _searchServices.searchLiked(recipeName, category, time, rating,user);
                    break;
            }

            mainVM.Recipes = recipes;

            foreach (var recipe in mainVM.Recipes)
            {
                recipe.Sender = await _userManager.FindByIdAsync(recipe.UserId);
            }

            mainVM.selectedCategory = category;
            mainVM.selectedTime = time;
            mainVM.selectedRating = rating;

            return View("RecipesSelect", mainVM);           
        }
                 
        [Authorize]
        [HttpGet]
        public IActionResult CreateRecipe()
        {
           
            return View("CreateRecipe");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateRecipe([Bind("RecipeId,RecipeName,RecipeTime,RecipeCategory,RecipePortions,RecipeInstructions,Ingridients")]Recipe recipe,List<IFormFile> images)
        {
            recipe.Sender = await _userManager.GetUserAsync(User);
            recipe.UserId = recipe.Sender.Id;
            recipe.PostedOn = DateTime.Now;
         
            await _appDb.AddAsync(recipe);

            await _appDb.SaveChangesAsync();

            foreach (var image in images)
            {
                await _uploadServices.UploadingRecipePhoto(image, recipe.Sender, recipe.RecipeId);
            }
           
            return RedirectToAction("GetRecipe",recipe.RecipeId);                       
        }
      
        [HttpGet]
        public async Task<IActionResult> GetRecipe(int id)
        {
            Recipe recipe = _appDb.Recipes.Find(id);
           

            var sender = await _userManager.FindByIdAsync(recipe.UserId);

            RecipeVM recipeVM = new RecipeVM();

            recipeVM.RecipeId = recipe.RecipeId;
            recipeVM.RecipeName = recipe.RecipeName;
            recipeVM.RecipeCategory = recipe.RecipeCategory;
            recipeVM.RecipePortions = recipe.RecipePortions;
            recipeVM.RecipeTime = recipe.RecipeTime;
            recipeVM.RecipeInstructions = recipe.RecipeInstructions;
            recipeVM.Ingridients = _appDb.Ingridients.Where(r => id == r.RecipeId).ToList();
            recipeVM.Rating = _ratingServices.GetRecipeRating(recipe.RecipeId);
            recipeVM.Sender = sender;
            recipeVM.PostedOn = recipe.PostedOn;
            recipeVM.Images = _appDb.Images.Where(i => i.RecipeId == recipe.RecipeId && i.UserId == recipe.UserId).ToList();
            recipeVM.Comments = _appDb.Comments.Where(c => c.RecipeId == id).ToList();

            foreach(var comment in recipeVM.Comments)
            {
                comment.Likes = _appDb.CommentLikes.Where(c => c.CommentId == comment.CommentID && c.isLike == true).ToList().Count;
                comment.Dislikes = _appDb.CommentLikes.Where(c => c.CommentId == comment.CommentID && c.isDislike == true).ToList().Count;
                if (_appDb.CommentLikes.Where(c => c.CommentId == comment.CommentID && c.isLike == true && c.UserId == _userManager.GetUserId(User)).Any() == true)
                    comment.Reacted = "like-pressed";
                if (_appDb.CommentLikes.Where(c => c.CommentId == comment.CommentID && c.isDislike == true && c.UserId == _userManager.GetUserId(User)).Any() == true)
                    comment.Reacted = "dislike-pressed";
            }
            
            return View("RecipePage",recipeVM);
        }

        [Authorize]
        public async Task<IActionResult> RateRecipe(int recipeId,int rate)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                Rating rating = new Rating();
                rating.RecipeId = recipeId;
                rating.UserId = user.Id;
                rating.Rate = rate;

                await _ratingServices.Rate(rating, user,recipeId);

                return Ok();
            }

            return View("Error");
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> LeaveComment(int id,string text)
        {
            
            if (ModelState.IsValid)
            {
                Comment comment = new Comment();
                comment.RecipeId = id;
                comment.Text = text;
                comment.UserName = User.Identity.Name;
                var sender = await _userManager.GetUserAsync(User);
                comment.UserId = sender.Id;
                comment.Sender = sender;
                await _cServices.PostComment(comment);

                var comments = _cServices.GetAllComments(comment.RecipeId);

                return PartialView("_Comment", comments);
            }


            return View("Error");
        }

        [Authorize]
        public async Task<IActionResult> DeleteComment(Comment comment)
        {           
                if (ModelState.IsValid)
                {
                    if (comment.UserId == _userManager.GetUserId(User))
                        await _cServices.DeleteComment(comment);
                   
                    return Ok();
                }
            
            return View("Error");
        }

        [Authorize]
        public async Task<IActionResult> EditComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _appDb.Comments.Remove(comment);
                await _appDb.Comments.AddAsync(comment);
                await _appDb.SaveChangesAsync();
                return Ok();
            }

            return View("Error");
        }
     
       [Authorize]
        public async Task<IActionResult> OnLikeClick(Comment comment)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);

               await _cServices.CommentLiking(comment, userId);

                return Ok();
            }

            return View("Error");
        }

        [Authorize]
        public async Task<IActionResult> OnDislikeClick(Comment comment)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);

                await _cServices.CommentDisliking(comment, userId);

                return Ok();
            }

            return View("Error");
        }
    }
}