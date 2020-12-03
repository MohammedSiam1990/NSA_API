﻿using AutoMapper;
using Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]

    public class UserDefinedController : Controller
    {
        private IUserDefinedService UserDefined;
        private IMapper Mapper;

        public UserDefinedController(IUserDefinedService _UserDefined, IMapper _Mapper)
        {
            UserDefined = _UserDefined;
            Mapper = _Mapper;
        }
        [HttpPost("SaveUserDefined")]
        public IActionResult SaveUserDefined(UserDefinedObjectsModel model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var UserD = Mapper.Map<UserDefinedObjects>(model);

                int reult = UserDefined.SaveUserDefined(UserD);
                if (reult != 1)
                {
                    if (reult == -1)
                    {
                        return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
                    }
                    if (reult == -2)
                    {
                        return Ok(new { success = false, message = lang.English_name_already_exists, repeated = "NameEn" });
                    }
                    if (reult == -3)
                    {
                        return Ok(new { success = false, message = lang.Arabic_name_already_exists, repeated = "NameAr" });
                    }
                }
                return Ok(new { success = true, message = lang.Saved_successfully_completed });

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }
        [HttpGet("GetUserDefined")]

        public IActionResult GetUserDefined(int? CompanyID, int? TypeID, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = UserDefined.GetUserDefined(CompanyID, TypeID);

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