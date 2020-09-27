using Exceptions;
using ImagesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS.Core.Resources;
using POS.Service.IService;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;

namespace POS.API.CORE.Controllers
{
    //  [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OperationsController : ControllerBase
    {
        private IlookUpService loockUpService;
        private IDeleteRecordService DeleteRecord;
        private IMobileDataService AllDataService;
        private ImagesPath imagesPath;



        public OperationsController(IlookUpService _loockUpService, ImagesPath _imagesPath, IMobileDataService _AllDataService, IDeleteRecordService _DeleteRecord)
        {
            loockUpService = _loockUpService;
            AllDataService = _AllDataService;
            imagesPath = _imagesPath;
            DeleteRecord = _DeleteRecord;
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
                
                 //if (Request.ContentLength > Int32.Parse(WebConfigurationManager.AppSettings["FileSize"]))
                 //   return new { success = false, message = lang.Your_file_was_not_uploaded_because + "," + lang.It_exceeds_the + WebConfigurationManager.AppSettings["FileSize"] + " KB " + lang.Size_limit };

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
                            ImagesNameList[i] = fileName;
                            i++;

                        }

                    }
                    return Ok(new { success = true, message = lang.Upload_image_successful, filePath = "http://posapi.opos.me/" + "uploads/" + FolderName + "/", ImagesName = ImagesNameList });

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
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

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
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });


        }
        [HttpGet("GetMobileData")]
        public IActionResult GetMobileData(int CompanyID)
        {

            try
            {
                var data = AllDataService.GetMobileData(CompanyID, imagesPath.Brand, imagesPath.Branch, imagesPath.ItemGroup);

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
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });


        }
        [HttpPost("DeleteRecord")]
        public IActionResult DeleteRecords(string TableNme, string TableKey, int RowID, string DeletedBy)
        {
            try
            {

                var data = DeleteRecord.DeleteRecord(TableNme, TableKey, RowID, DeletedBy);
                if (data != 1)
                {
                    return Ok(new { success = false, message = lang.Deleted_Faild });
                }
                else
                {
                    return Ok(new { success = true, message = lang.Deleted_successfully });
                }

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
                // return error message if there was an exception

            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }

    }
}
