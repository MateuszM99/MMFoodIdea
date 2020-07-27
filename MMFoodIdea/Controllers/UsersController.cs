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
using MMFoodIdea.Data;

namespace MMFoodIdea.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _appDb;

        public UsersController(UserManager<AppUser> userManager, ApplicationDbContext appDb)
        {
            _appDb = appDb;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddProfilePic(IFormFile imageFile)
        {
            
            string extension = Path.GetExtension(imageFile.FileName);

            string path = String.Format("wwwroot/images/Users/{0}",_userManager.GetUserId(User));

            if(!Directory.Exists(path))
            Directory.CreateDirectory(path);

            var memoryStream = new MemoryStream();

            await imageFile.CopyToAsync(memoryStream);

            System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream);
            
            switch (extension.ToLower())
            {
                case ".bmp":
                    image.Save(path + "/" + imageFile.FileName, ImageFormat.Bmp);
                    break;
                case ".exif":
                    image.Save(path + "/" + imageFile.FileName, ImageFormat.Exif);
                    break;
                case ".gif":
                    image.Save(path + "/" + imageFile.FileName, ImageFormat.Gif);
                    break;
                case ".jpg":
                case ".jpeg":
                    image.Save(path + "/" + imageFile.FileName, ImageFormat.Jpeg);
                    break;
                case ".png":
                    image.Save(path + "/" + imageFile.FileName, ImageFormat.Png);
                    break;
                case ".tif":
                case ".tiff":
                    image.Save(path + "/" + imageFile.FileName, ImageFormat.Tiff);
                    break;
                default:
                    throw new NotSupportedException(
                        "Unknown file extension " + extension);                    
            }

            MMFI_Entites.Models.Image dbImage = new MMFI_Entites.Models.Image();

            dbImage.ImagePath = path + "/" + imageFile.FileName;

            dbImage.UserId = _userManager.GetUserId(User);

            _appDb.Images.Add(dbImage);

            await _appDb.SaveChangesAsync();

            return Ok();

        }




    }
}