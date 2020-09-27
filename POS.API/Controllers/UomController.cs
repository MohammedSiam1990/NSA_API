using AutoMapper;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using POS.API.Models;
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
    public class UomController : ControllerBase
    {
        private IUomService uomService;
        private IMapper Mapper;

        public UomController(IUomService _uomService,
                              IMapper mapper
                                )
        {
            uomService = _uomService;
            Mapper = mapper;
        }


        [HttpGet("GetUoms")]
        public IActionResult GetUoms(int companyId = 0, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = uomService.GetProcUoms(companyId);
                if (data != null)
                {
                    if (data.Count() == 0)
                    {
                        return Ok(new { success = true, message = lang.No_data_available, datalist = data.ToList() });
                    }
                    else
                    {
                        return Ok(new { success = true, message = "", datalist = data.ToList() });
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

        [HttpPost("Save_Uom")]
        public IActionResult Save_Uom(UomModel model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var uom = Mapper.Map<Uom>(model);
                var data = uomService.SaveProcUom(uom);
                if (data != 1)
                {
                    if (data == -1)
                    {
                        return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

                    }
                    if (data == -2)
                    {
                        return Ok(new { success = false, message = lang.English_name_already_exists, repeated = "UomName" });
                    }
                    if (data == -3)
                    {
                        return Ok(new { success = false, message = lang.Arabic_name_already_exists, repeated = "UomNameAr" });
                    }
                }
                else
                {
                    return Ok(new { success = true, message = lang.Saved_successfully_completed });
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
