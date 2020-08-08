using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MMFI_Entites.Models;
using MMFI_IServices;
using MMFoodIdea.Data;

namespace MMFoodIdea.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _appDb;
        private readonly IUploadServices _uploadServices;

        public UsersController(UserManager<AppUser> userManager, ApplicationDbContext appDb,IUploadServices uploadServices)
        {
            _appDb = appDb;
            _userManager = userManager;
            _uploadServices = uploadServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddProfilePic(IFormFile imageFile)
        {
            var user = await _userManager.GetUserAsync(User);

            await _uploadServices.UploadingProfilePhoto(imageFile, user);
       

            return Ok();

        }




    }
}