using Microsoft.AspNetCore.Http;
using MMFI_IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MMFI_Services
{
    public class UploadImage : IUploadImage
    {
        public byte[] Upload(IFormFile file)
        {

            byte[] image = new byte[file.Length];

            var memoryStream = new MemoryStream();

            file.CopyTo(memoryStream);

            image = memoryStream.ToArray();

            return image;

        }
    }
}