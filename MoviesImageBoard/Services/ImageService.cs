using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace MoviesImageBoard.Services
{
    public class ImageService
    {
        private readonly IWebHostEnvironment _hostingEnv;

        public ImageService(IWebHostEnvironment hostingEnv)
        {
            _hostingEnv = hostingEnv;
        }

        public async Task<string> SavePicture(IFormFile formFile)
        {

            var fileName = GetUniqueFileName(formFile.FileName);

            var filePath = Path.Combine(_hostingEnv.WebRootPath, "images", fileName);

            using (var fileSteam = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(fileSteam);
                fileSteam.Close();
            }

            return fileName;
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}
