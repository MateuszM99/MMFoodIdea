using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMFI_Data.Data;
using MMFI_Entites.Models;
using MMFI_Entites.ViewModels;
using MMFI_IServices;
using MMFoodIdea.Data;

namespace MMFoodIdea.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _appDb;
        private readonly ICommentServices _cServices;
        private readonly UserManager<AppUser> _userManager;
        public RecipesController(ApplicationDbContext appDb, ICommentServices cServices, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _appDb = appDb;
            _cServices = cServices;
        }

        public async Task<IActionResult> Index(int? id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Select()
        {
            RecipesMainVM mainVM = new RecipesMainVM();

            mainVM.Recipes = _appDb.Recipes.ToList();

            return View("RecipesSelect",mainVM);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Users()
        {
            return View("UsersProfile");
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateRecipe()
        {
           
            return View("CreateRecipe");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateRecipe(Recipe recipe)
        {
            recipe.Sender = await _userManager.GetUserAsync(User);
            recipe.UserId = recipe.Sender.Id;
            recipe.PostedOn = DateTime.Now;

            var images = _appDb.Images.Where(i => i.RecipeId == recipe.RecipeId && i.UserId == recipe.UserId).ToList();

            recipe.Images = images;

            await _appDb.AddAsync(recipe);

            await _appDb.SaveChangesAsync();

            RecipeVM recipeVM = new RecipeVM();

            recipeVM.RecipeName = recipe.RecipeName;
            recipeVM.RecipeCategory = recipe.RecipeCategory;
            recipeVM.RecipePortions = recipe.RecipePortions;
            recipeVM.RecipeTime = recipe.RecipeTime;
            recipeVM.RecipeInstructions = recipe.RecipeInstructions;
            recipeVM.Sender = recipe.Sender;
            recipeVM.PostedOn = recipe.PostedOn;
            recipeVM.Images = recipe.Images;

            return View("RecipePage", recipeVM);
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
            recipeVM.Sender = sender;
            recipeVM.PostedOn = recipe.PostedOn;
            recipeVM.Images = recipe.Images;
            recipeVM.Comments = _appDb.Comments.Where(c => c.RecipeId == id).ToList();

            foreach(var comment in recipeVM.Comments)
            {
                comment.Likes = _appDb.CommentLikes.Where(c => c.CommentId == comment.CommentID && c.isLike == true).ToList().Count;
                comment.Dislikes = _appDb.CommentLikes.Where(c => c.CommentId == comment.CommentID && c.isDislike == true).ToList().Count;
            }

            return View("RecipePage",recipeVM);
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

       [HttpPost]
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