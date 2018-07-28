using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YdsHouston.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        // GET api/upload
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value3" };
        }

        // POST api/upload
        [HttpPost]
        public async void Post()
        {
            var files = Request.Form;
            string folder = "general";
            
            foreach(var cur_file in files.Files)
            {
                switch (Path.GetExtension(cur_file.FileName))
                {
                    case ".png":
                    case ".jgp":
                    case ".jpeg":
                    case ".gif":
                        folder = "general";
                        break;
                    case ".mp3":
                    case ".mp4":
                        folder = "audio";
                        break;
                    default:
                        folder = "general";
                        break;
                }
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{folder}");
                using (var fileStream = new FileStream(Path.Combine(filePath, cur_file.FileName), FileMode.Create))
                {
                    await cur_file.CopyToAsync(fileStream);
                }
            }
        }
    }
}