using Exceptions;
using ImagesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS.Core.Resources;
using POS.Service.IService;
using System;
using System.Globalization;
using System.Threading;

namespace POS.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]

    public class MobileController : Controller
    {
        private ImagesPath imagesPath;
        private IMobileDataService AllDataService;

        public MobileController(ImagesPath _imagesPath, IMobileDataService _AllDataService)
        {
            imagesPath = _imagesPath;
            AllDataService = _AllDataService;
        }
        [DisableRequestSizeLimit]
        [HttpGet("GetMobileData")]
        public IActionResult GetMobileData(int CompanyID, string Lang = "en")
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

            try
            {
                var data = AllDataService.GetMobileData(CompanyID, imagesPath.Brand, imagesPath.Branch, imagesPath.ItemGroup, imagesPath.Item);

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


        [HttpGet("CheckSerialNumber")]
        public IActionResult CheckSerialNumber(int CompanyID, string Serial, string Lang = "en")
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

            try
            {
                var data = AllDataService.CheckSerialNumber(CompanyID, Serial);

                if (data == 1)
                {
                    return Ok(new { success = true, message = "" });
                }
                else if (data == -2)
                {
                    return Ok(new { success = false, message = lang.This_serial_number_does_not_exists });
                }
                else if (data == -3)
                {
                    return Ok(new { success = false, message = lang.This_serial_is_used_by_another_workstation });
                }
                else if (data == -4)
                {
                    return Ok(new { success = false, message = lang.This_serial_is_related_to_another_company_you_can_t_use_it });
                }

                else
                {
                    return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
                }
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });


        }

        [HttpGet("UpdateSerialNumber")]
        public IActionResult UpdateSerialNumber(int CompanyID, string Serial, string Mac, string Lang = "en")
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

            try
            {
                var data = AllDataService.UpdateSerialNumber(CompanyID, Serial, Mac);

                if (data >= 1)
                {
                    return Ok(new { success = true, message = "", WorkStationID = data });
                }
                else if (data == -2)
                {
                    return Ok(new { success = false, message = lang.This_serial_number_does_not_exists });
                }
                else if (data == -3)
                {
                    return Ok(new { success = false, message = lang.This_serial_is_used_by_another_workstation });
                }
                else if (data == -4)
                {
                    return Ok(new { success = false, message = lang.This_serial_is_related_to_another_company_you_can_t_use_it });
                }

                else
                {
                    return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
                }
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

    }
}