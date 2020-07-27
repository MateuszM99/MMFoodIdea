using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MMFI_IServices
{
    public interface IUploadServices
    {
        Task UploadingPhoto(IFormFile imageFile);


    }
}
