using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using POS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ManagingProduct.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadDownloadController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;

        public UploadDownloadController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("upload")]
        //public async Task<object> Upload(IFormFile formdata)
        //{
        //    var file = Request.Form.Files[0];
        //    var files = HttpContext.Request.Form.Files;
        //    var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "uploads");
        //    //  var rand= GeneralUtils.RandomString(3, false);

        //    if (!Directory.Exists(uploads))
        //    {
        //        Directory.CreateDirectory(uploads);
        //    }
        //    if (file.Length > 0)
        //    {
        //        var filePath = Path.Combine(uploads, file.FileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await file.CopyToAsync(fileStream);
        //        }
        //    }
        //    return Ok(new RequestResault { Message = "Uploaded Succefully", Status = "200", Data = file.FileName });
        //}
     
        //[AllowAnonymous]
        //[HttpPost]
        //[Route("UploadPath/{pathName}/{FolderName}")]
        //public async Task<object> UploadPath(IFormFile formdata,string pathName,string FolderName)
        //{
        //    var file = Request.Form.Files[0];
        //    var files = HttpContext.Request.Form.Files;
        //    var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "uploads", pathName,FolderName);
        //    //  var rand= GeneralUtils.RandomString(3, false);
        
        //    if (!Directory.Exists(uploads))
        //    {
        //        Directory.CreateDirectory(uploads);
        //    }
        //    if (file.Length > 0)
        //    {
        //        var filePath = Path.Combine(uploads, file.FileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await file.CopyToAsync(fileStream);
        //        }
        //    }
        //    return Ok(new RequestResault { Message = "Uploaded Succefully", Status = "200", Data = file.FileName });
        //}
        [HttpGet]
        [Route("download")]
        public async Task<IActionResult> Download([FromQuery] string file)
        {

            if (string.IsNullOrWhiteSpace(_hostingEnvironment.WebRootPath))
            {
                _hostingEnvironment.WebRootPath = Directory.GetCurrentDirectory();// Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }
            var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "uploads");
            var filePath = Path.Combine(uploads, file);
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(filePath), file);
        }

        [HttpGet]
        [Route("files")]
        public IActionResult Files()
        {
            var result = new List<string>();

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            if (Directory.Exists(uploads))
            {
                var provider = _hostingEnvironment.ContentRootFileProvider;
                foreach (string fileName in Directory.GetFiles(uploads))
                {
                    var fileInfo = provider.GetFileInfo(fileName);
                    result.Add(fileInfo.Name);
                }
            }
            return Ok(result);
        }


        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}
