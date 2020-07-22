using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public RecipesController(ApplicationDbContext appDb, ICommentServices cServices)
        {
            _appDb = appDb;
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
          //  _appDb.Recipes.Add(recipe);
            _appDb.SaveChanges();

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


            return View("Error");
        }

        public async Task<IActionResult> DeleteComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                await _cServices.DeleteComment(comment);
                return Ok();
            }

            return View("Error");
        }


    }
}