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
            return View("Error");
        }
    }
}