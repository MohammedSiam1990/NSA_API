using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS.API.Models;
using POS.Core.Resources;
using POS.Data.Entities;
using POS.Service.IService;

namespace POS.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]

    public class ConfigController : Controller
    {
        private IconfigService ConfigService;
        private IMapper Mapper;

        public ConfigController(IMapper mapper, IconfigService _ConfigService)
        {
            ConfigService = _ConfigService;
            Mapper = mapper;

        }
        [HttpPost("SaveConfig")]
        public IActionResult SaveConfig(List<Config> model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                //var Customer = Mapper.Map<list>(model);

                int result = ConfigService.SaveConfig(model);
                if (result == 1)
                {
                    return Ok(new { success = true, message = lang.Saved_successfully_completed });

                }

                else if (result == -2)
                {
                    return Ok(new { success = false, message = lang.Please_reload_the_page });
                }

                else
                {
                    return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
                }
            }
            catch (Exception ex)
            {

                ExceptionError.SaveException(ex);
                // return error message if there was an exception

            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }

        [HttpGet("GetConfig")]
        public IActionResult GetConfig(string TabID, int TypeID,int? BranchID=null,int? BrandID=null, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = ConfigService.GetConfig(TabID,TypeID,BranchID, BrandID);
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

    }
}