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
        [HttpPost("SaveCustomer")]
        public IActionResult SaveCustomer(List<Config> model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                //var Customer = Mapper.Map<list>(model);

                ConfigService.SaveConfig(model);
                return Ok(new { success = true, message = lang.Saved_successfully_completed });


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