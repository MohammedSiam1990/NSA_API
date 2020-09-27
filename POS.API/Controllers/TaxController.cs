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
    public class TaxController : ControllerBase
    {
        private ITaxService taxService;
        private IMapper Mapper;

        public TaxController(ITaxService _taxService,
                              IMapper mapper
                                )
        {
            taxService = _taxService;
            Mapper = mapper;
        }


        [HttpGet("GetTaxes")]
        public IActionResult GetTaxes(int companyId = 0, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = taxService.GetProcTaxes(companyId);
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

        [HttpPost("Save_Tax")]
        public IActionResult Save_Tax(TaxModel model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var tax = Mapper.Map<Tax>(model);
                var data = taxService.SaveProcTax(tax);
                if (data != 1)
                {
                    if (data == -1)
                    {
                        return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

                    }

                    if (data == -2)
                    {
                        return Ok(new { success = false, message = lang.English_name_already_exists, repeated = "taxName" });
                    }
                    if (data == -3)
                    {
                        return Ok(new { success = false, message = lang.Arabic_name_already_exists, repeated = "taxNameAr" });
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