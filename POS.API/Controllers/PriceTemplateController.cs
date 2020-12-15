using AutoMapper;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS.API.Models;
using POS.Common;
using POS.Core.Resources;
using POS.Data.Entities;
using POS.Service.IService;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceTemplateController : ControllerBase
    {
        private IPriceTemplateService PriceTemplateService;

        private IMapper Mapper;

        public PriceTemplateController(IPriceTemplateService _PriceTemplateService, IMapper _Mapper)
        {
            PriceTemplateService = _PriceTemplateService;
            Mapper = _Mapper;
        }


        [HttpPost("SavePriceTemplate")]
        public IActionResult SavePriceTemplate(PriceTemplateModel model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
                string ParamName;
                bool valid = CommandTextValidator.ValidateStatement(out ParamName, model.Name, model.NameAr,model.TypeName);
                if (valid == false)
                {
                    return Ok(new { success = false, Name = ParamName, message = lang.Please_Remove_special_characters });
                }

                var Price = Mapper.Map<PriceTemplate>(model);
                int data = PriceTemplateService.ValidateNameAlreadyExist(Price);

                if (data == 1)
                {
                    PriceTemplateService.SavePriceTemplate(Price);
                    return Ok(new { success = true, message = lang.Saved_successfully_completed });
                }
                else if (data == -1)
                    return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
                else if (data == -2)
                    return Ok(new { success = false, message = lang.English_name_already_exists, repeated = "Name" });
                else if (data == -3)
                    return Ok(new { success = false, message = lang.Arabic_name_already_exists, repeated = "NameAr" });
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }


        [HttpGet("GetPriceTemplate")]
        public IActionResult GetPriceTemplate(int BrandID = 0, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = PriceTemplateService.GetPriceTemlate(BrandID);
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
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }


    }
}