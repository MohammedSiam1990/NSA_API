using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS.API.Models;
using POS.Core.Resources;
using POS.Data.Entities;
using POS.Service.IService;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private IPermissionsService PermissionsService;
        private IMapper Mapper;

        public PermissionsController(IMapper mapper, IPermissionsService _PermissionsService)
        {
            PermissionsService = _PermissionsService;
            Mapper = mapper;
        }

        [HttpGet("GetPermissions")]
        public IActionResult GetPermissions(int MenuType, int RoldID, int? BrandID, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = PermissionsService.GetPermissions(MenuType, RoldID, BrandID);
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


        [HttpPost("SavePermissions")]
        public IActionResult SavePermissions(List<PermissionsModel> model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
                var Permission = Mapper.Map<List<Permissions>>(model);
                int rollId = Permission.First().RoleID;

                PermissionsService.SavePermissions(Permission, rollId);

                return Ok(new { success = true, message = lang.Saved_successfully_completed });



            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }

    }
}