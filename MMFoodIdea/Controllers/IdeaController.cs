using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MMFI_Entites.Models;
using MMFI_Entites.ViewModels;

namespace MMFoodIdea.Controllers
{
    public class IdeaController : Controller
    {
        public IActionResult Index()
        {
            RecipeBrowseVM rbVM = new RecipeBrowseVM();

            rbVM.Recipes = new List<Recipe>();

            Recipe rec1 = new Recipe
            {
                RecipeId = 1,
                RecipeName = "Test",
                RecipeTime = 10,

            };

            Recipe rec2 = new Recipe
            {
                RecipeId = 2,
                RecipeName = "Test",
                RecipeTime = 20,

            };

            rbVM.Recipes.Add(rec1);
            
            rbVM.Recipes.Add(rec2);


            return View(rbVM);
        }
    }
}