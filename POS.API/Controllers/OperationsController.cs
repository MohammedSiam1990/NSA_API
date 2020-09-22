﻿using System;
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
using Newtonsoft.Json;
using POS.Services;
using POS.Service.IService;
using POS.Core.Resources;
using AutoMapper.Configuration;
using System.Text;

namespace POS.API.CORE.Controllers
{
    //  [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OperationsController : ControllerBase
    {
        private IlookUpService loockUpService;
        private  IMobileDataService AllDataService;
        private ImagesPath imagesPath;



        public OperationsController(IlookUpService _loockUpService, ImagesPath _imagesPath,IMobileDataService _AllDataService)
        {
            loockUpService = _loockUpService;
            AllDataService = _AllDataService;
            imagesPath = _imagesPath;
        }
        [AllowAnonymous]
        [HttpPost("UploadImage")]
        public IActionResult UploadImage(string FolderName, string Lang = "en")
        {
            try
            {
                //var file = Request.Form.Files.Count();
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var folderName = Path.Combine("uploads", FolderName);
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
                            ImagesNameList[i] =  fileName;
                            i++;

                        }

                    }
                    return Ok(new { success = true, message = lang.Upload_image_successful, filePath = "http://posapi.opos.me/" + "uploads/" + FolderName + "/" , ImagesName = ImagesNameList });

                }
                else
                {
                    return Ok(new { success = false, message = lang.Select_image_file_to_upload });
                }
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return BadRequest(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

        [HttpGet("GetLookup")]
        public IActionResult GetLookup(string Lang = "en")
        {

            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);


                var data = loockUpService.GetLookUps(Lang);

                if (data == null)
                {
                    return Ok(new { success = false, message = lang.No_data_available });
                }
                else
                {
                    return Ok(new { success = true, message = "", datalist = JsonConvert.DeserializeObject(data) });
                }
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);

            }
            return BadRequest(new { success = false, message = lang.An_error_occurred_while_processing_your_request });


        }
        [HttpGet("GetMobileData")]
        public IActionResult GetMobileData(int CompanyID)
        {

            try
            {
                var data = AllDataService.GetMobileData(CompanyID, imagesPath.brand, imagesPath.branch, imagesPath.itemGroup);

                if (data == null)
                {
                    return Ok(new { success = false, message = lang.No_data_available });
                }
                else
                {
                    return Ok(new { success = true, message = "", datalist = data.ToList() });
                }
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);

            }
            return BadRequest(new { success = false, message = lang.An_error_occurred_while_processing_your_request });


        }

    }
}
