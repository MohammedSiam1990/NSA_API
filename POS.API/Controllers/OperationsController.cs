using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Pos.IService;
using POS.Models;
using Pos.Service;
using POS.Entities;
using System.Linq;
using POS.Common;
using static POS.Common.Enums;
using System.Globalization;
using System.Threading;
using ImagesService;
using Exceptions;
using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using POS.Core.Resources;

namespace POS.API.CORE.Controllers
{
    //  [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OperationsController : ControllerBase
    {
        private readonly IHostEnvironment _env;

        [AllowAnonymous]
        [HttpPost]
        [ActionName("UploadImage")]
        public object UploadImage(string FolderName, string Lang = "en")
        {
            try
            {
                //var file = Request.Form.Files.Count();
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var folderName = Path.Combine("uploads",FolderName);
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                string[] ImagesNameList = new string[Request.Form.Files.Count()];

                if (Request.Form.Files.Count() > 0)
                {
                    int i = 0;
                    foreach (IFormFile file in Request.Form.Files)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        if (i < Request.Form.Files.Count())
                        {
                            ImagesNameList[i] = FolderName+"/"+fileName;
                            i++;

                        }

                    }
                    return new { success = true, message =lang.Upload_image_successful, filePath = "http://posapi.opos.me/" + "uploads/" + FolderName + "/", ImagesName = ImagesNameList };

                }
                else
                {
                    return new { success = false, message = lang.Select_image_file_to_upload };
                }
            }
            catch (Exception ex)
            {
                return new { success = false, message = lang.An_error_occurred_while_processing_your_request };
            }

        }
    }
}
