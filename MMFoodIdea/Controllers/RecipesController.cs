﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MMFI_Data.Data;
using MMFI_Entites.Models;
using MMFI_Entites.ViewModels;
using MMFI_IServices;

namespace MMFoodIdea.Controllers
{
    public class RecipesController : Controller
    {
        private readonly RecipeDbContext _recipeDb;
        private readonly ICommentServices _cServices;
        public RecipesController(RecipeDbContext recipeDb,ICommentServices cServices)
        {
            _recipeDb = recipeDb;
            _cServices = cServices;
        }

        public IActionResult Index(int? id)
        {
            CommentVM cvm = new CommentVM();
            
            if (id == null)
                return View("Index",cvm);

            

            cvm.comments = _cServices.GetAllComments(id);

            return View(cvm);
        }

        [HttpPost]
        public IActionResult CreateRecipe(Recipe recipe)
        {
            _recipeDb.Recipes.Add(recipe);
            _recipeDb.SaveChanges();

            return RedirectToAction("Index");
        }

       
        [HttpPost]
        public async Task<IActionResult> LeaveComment(Comment comment)
        {

            if (ModelState.IsValid)
            {                
                await _cServices.PostComment(comment);
                return Ok();
            }


            return View("Error",!ModelState.IsValid);
        }
    }
}