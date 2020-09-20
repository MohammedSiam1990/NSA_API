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

namespace POS.API.CORE.Controllers
{
  //  [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OperationsController : ControllerBase
    {

        [AllowAnonymous]
        [HttpPost]
        [ActionName("UploadImage")]
        public object UploadImage(string FolderName, string Lang = "en")
        {
            try
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                string Extension = string.Empty;
                string CurrentFileName = string.Empty;
                string NewFileName = string.Empty;
                var httpRequest = HttpContext.Current.Request;
                string[] ImagesNameList = new string[httpRequest.Files.Count];
                if (httpRequest.Files.Count > 0)
                {
                    int i = 0;
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];

                        if (postedFile.ContentLength > 250)
                            return new { success = false, message = Resources.lang.Your_file_was_not_uploaded_because + "," + Resources.lang.It_exceeds_the + "250" + " KB " + Resources.lang.Size_limit };


                        Extension = Path.GetExtension(postedFile.FileName);
                        CurrentFileName = Path.GetFileName(postedFile.FileName);

                        if (File.Exists(HttpContext.Current.Server.MapPath("~/Content/Images/" + FolderName + "/" + CurrentFileName + Extension)))
                        {
                            File.Delete(HttpContext.Current.Server.MapPath("~/Content/Images/" + FolderName + "/" + CurrentFileName + Extension));
                        }

                        NewFileName = Guid.NewGuid().ToString();
                        var filePath = HttpContext.Current.Server.MapPath("~/Content/Images/" + FolderName + "/" + NewFileName + Extension);
                        postedFile.SaveAs(filePath);
                        if (i < httpRequest.Files.Count)
                        {
                            ImagesNameList[i] = NewFileName + Extension;
                            i++;

                        }
                    }
                    return new { success = true, message = POSAPI.Resources.lang.Upload_image_successful, filePath = WebConfigurationManager.AppSettings["URL"] + "Content/Images/" + FolderName + "/", ImagesName = ImagesNameList };

                }
                else
                {
                    return new { success = false, message = POSAPI.Resources.lang.Select_image_file_to_upload };
                }

            }
            catch (Exception ex)
            {

                ExceptionError(ex);
            }
            return new { success = false, message = POSAPI.Resources.lang.Upload_image_failed };

        }





    }
}
