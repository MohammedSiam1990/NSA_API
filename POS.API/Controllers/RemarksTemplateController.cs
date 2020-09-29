using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS.Core.Resources;
using POS.Service.IService;

namespace POS.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class RemarksTemplateController : Controller
    {
        private IRemarksTemplateService RemarksTemplateService;

        public RemarksTemplateController(IRemarksTemplateService _RemarksTemplateService)
        {
            RemarksTemplateService = _RemarksTemplateService;
        }
        [AllowAnonymous]
        [HttpGet("GetRemarksTemplates")]
        public IActionResult GetRemarksTemplates(int BrandID, string Lang = "en")
        {

            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = RemarksTemplateService.GetRemarksTemplate(BrandID);

                if (data != null)
                {
                    if (data.Count() == 0)
                    {
                        return Ok(new { success = true, message = lang.No_data_available, datalist = data.ToList() });
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

    }
}