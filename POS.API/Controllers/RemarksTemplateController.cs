using AutoMapper;
using Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS.API.Models;
using POS.Core.Resources;
using POS.Entities;
using POS.Service.IService;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace POS.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class RemarksTemplateController : Controller
    {
        private IRemarksTemplateService RemarksTemplateService;
        private IMapper Mapper;
        public RemarksTemplateController(IRemarksTemplateService _RemarksTemplateService, IMapper mapper)
        {
            RemarksTemplateService = _RemarksTemplateService;
            Mapper = mapper;
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
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }

        [HttpPost("SaveRemarksTemplates")]
        public IActionResult SaveRemarksTemplates(RemarksTemplateModel model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
                var remarksTemplate = Mapper.Map<RemarksTemplate>(model);
                int RemarksTemplateIdentity = 0;
                int data = RemarksTemplateService.ValidateNameAlreadyExist(remarksTemplate);

                if (data == 1)
                {
                    if (remarksTemplate.RemarksTemplateId == 0)
                        RemarksTemplateIdentity = RemarksTemplateService.AddRemarksTemplate(remarksTemplate);
                    else
                    {
                        RemarksTemplateIdentity = model.RemarksTemplateId;
                        RemarksTemplateService.UpdateRemarksTemplate(remarksTemplate);
                    }
                    return Ok(new { success = true, message = lang.Saved_successfully_completed, id = RemarksTemplateIdentity });
                }
                else if (data == -1)
                    return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
                else if (data == -2)
                    return Ok(new { success = false, message = lang.English_name_already_exists, repeated = "remarksTemplateName" });
                else if (data == -3)
                    return Ok(new { success = false, message = lang.Arabic_name_already_exists, repeated = "remarksTemplateNameAr" });
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }


    }
}
