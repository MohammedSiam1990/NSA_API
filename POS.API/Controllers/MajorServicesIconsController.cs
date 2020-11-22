using AutoMapper;
using EmailService;
using Exceptions;
using ImagesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pos.IService;
using POS.API.Helpers;
using POS.Core.Resources;
using POS.Entities;
using POS.Models;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;

namespace POS.API.CORE.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MajorServicesIconsController : ControllerBase
    {

        private ImagesPath imagesPath;

        Setting Setting;
        private IMajorServicesIconsService MajorServicesIconsService;
        private IMapper Mapper;

        public MajorServicesIconsController(
            IMajorServicesIconsService _MajorServicesIconsService,
            ImagesPath _imagesPath, Setting _Setting,
            IMapper mapper)
        {
            MajorServicesIconsService = _MajorServicesIconsService;
            Mapper = mapper;
            Setting = _Setting;
            imagesPath = _imagesPath;
        }


        [HttpPost("AddMajorServicesIcons")]
        public IActionResult Add([FromForm]MajorServicesIconsModel model, string Lang = "en")
        {

            // map model to entity
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
            var MajorServicesIcons = Mapper.Map<MajorServicesIcons>(model);
            try
            {
                    Guid gid = Guid.NewGuid();
                    MajorServicesIcons.IconName = gid.ToString() + ".svg";
                    var ImgResult =  UploadImage(model.FolderPath + MajorServicesIcons.IconName.ToString(), "", Lang);
                    if (ImgResult == -1)
                        return Ok(new { success = false, message = lang.Your_file_was_not_uploaded_because + "," + lang.It_exceeds_the + lang.Size_limit + ":" + Setting.imagefilesize + " KB " });
                    else if (ImgResult == -2)
                        return Ok(new { success = false, message = lang.Select_image_file_to_upload });
                    else
                      MajorServicesIconsService.AddMajorServicesIcons(MajorServicesIcons);
                    

                    return Ok(new { success = true, message = lang.Saved_successfully_completed });

                //  return Ok(new { message = "Data is Not Complete" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }


        [HttpPost("UpdateMajorServicesIcons")]
        public IActionResult Update([FromForm]MajorServicesIconsModel model, string Lang = "en")
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
            try
            {
                // map model to entity
                var MajorServicesIcons = Mapper.Map<MajorServicesIcons>(model);
                Guid gid = Guid.NewGuid();
                MajorServicesIcons.IconName = gid.ToString() + ".svg";
                var ImgResult = UploadImage(model.FolderPath + MajorServicesIcons.IconName.ToString(), model.IconName, Lang);

                if (ImgResult == -1)
                    return Ok(new { success = false, message = lang.Your_file_was_not_uploaded_because + "," + lang.It_exceeds_the + lang.Size_limit + ":" + Setting.imagefilesize + " KB " });
               else if (ImgResult == -2)
                    return Ok(new { success = false, message = lang.Select_image_file_to_upload });
                else
                    MajorServicesIconsService.UpdateMajorServicesIcons(MajorServicesIcons);
                
                return Ok(new { success = true, message = lang.Updated_successfully_completed });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                ExceptionError.SaveException(ex);
            }

        
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }




        [HttpPost("DeleteMajorServicesIcons")]
        public IActionResult Delete(int MajorServicesIconsId)
        {

            try
            {
                MajorServicesIconsService.DeleteMajorServicesIcons(MajorServicesIconsId);
                return Ok(new { success = true, message = lang.Deleted_successfully });

            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return Ok(new { message = ex.Message });
            }
        }


        [HttpGet("GetMajorServicesIcon/MajorServicesIconsId")]
        public IActionResult GetMajorServicesIcon(int MajorServicesIconsId)
        {
            try
            {
                // create user
                var MajorServicesIcons = MajorServicesIconsService.GetMajorServicesIcons(MajorServicesIconsId);
                var MajorServicesIconsDto = Mapper.Map<MajorServicesIconsModel>(MajorServicesIcons);

                return Ok(new { datalist = MajorServicesIconsDto, message = "", success = true });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

        [HttpGet("GetMajorServicesByIcons")]
        public IActionResult GetMajorServicesByIcons(int ServiceId, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = MajorServicesIconsService.GetMajorServicesByIcons(ServiceId);
                if (data != null)
                {
                    if (data.Count() == 0)
                    {
                        return Ok(new { success = true, message = lang.No_data_available, datalist = JsonConvert.DeserializeObject(data) });
                    }
                    else
                    {
                        return Ok(new { success = true, message = "", datalist = JsonConvert.DeserializeObject(data) });
                    }

                }
            }

            catch (Exception ex)
            {
                // return error message if there was an exception
                ExceptionError.SaveException(ex);

            }

            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }


        private int UploadImage(string folderPath, string OldPathIcon = "", string Lang = "en")
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

            var folderName = Path.Combine("uploads/ItemGroup", folderPath);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            string[] ImagesNameList = new string[Request.Form.Files.Count()];

            if (Request.ContentLength > Setting.imagefilesize)
                return -1;

            if (Request.Form.Files.Count() > 0)
            {
                int i = 0;
                foreach (IFormFile file in Request.Form.Files)
                {

                    var fullPath = Path.Combine(pathToSave);
                    var dbPath = Path.Combine(folderName);

                    if (OldPathIcon != "" && System.IO.File.Exists(OldPathIcon))
                    {
                        System.IO.File.Delete(OldPathIcon);
                    }
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {

                        file.CopyTo(stream);
                    }

                    if (i < Request.Form.Files.Count())
                    {
                        ImagesNameList[i] = "";
                        i++;

                    }

                }
                // return Ok(new { success = true, message = lang.Upload_image_successful, filePath = Setting.APIwebPath + "uploads/" + FolderName + "/", ImagesName = ImagesNameList });

            }
            else
            {
                return -2;
                // throw new ArgumentException(lang.Select_image_file_to_upload);
            }
            return 1;
        }

    }
}
