using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMFI_IServices
{
    public interface IUploadImage
    {
        byte[] Upload(IFormFile file);


    }
}
