using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pos.IService;
using POS.Core.Resources;
using POS.Data.DataContext;
using POS.Data.Dto.Account;
using POS.Data;
using Steander.Core.Entities;
using POS.Entities;
using ApplicationUser = Steander.Core.Entities.ApplicationUser;
using POS.API.Models;
using AutoMapper;
using POS.Service.IService;
using POS.Data.Entities;
using Newtonsoft.Json;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<AspNetRoles> roleManager;
        private UserManager<ApplicationUser> userManger;
        private IAccountService _accountService;
        private IRoleService RoleService;
        private IUserRoleService UserRoleService;
        private IMapper Mapper;

        public RolesController(RoleManager<AspNetRoles> _roleManager, UserManager<ApplicationUser> _userManger,
            IAccountService accountService, IRoleService _RoleService, IMapper _Mapper, IUserRoleService _UserRoleService)
        {
            roleManager = _roleManager;
            userManger = _userManger;
            _accountService = accountService;
            RoleService = _RoleService;
            Mapper = _Mapper;
            UserRoleService = _UserRoleService;
        }

        [HttpPost("CreateRole")]
        public IActionResult CreateRole(RoleModel model, string Lang = "en")
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
            try
            {
                var role = Mapper.Map<Role>(model);
                int result = RoleService.RoleAlreadyExists(role);
                if (result == 1)
                {
                    RoleService.SaveRole(role);
                    return Ok(new { success = true, message = lang.Saved_successfully_completed });
                }
                else if (result == -2)
                {
                    return Ok(new { success = false, message = lang.Name_already_exists , repeated = "Name" });
                }
                else if (result == -3)
                {
                    return Ok(new { success = false, message = lang.Arabic_name_already_exists , repeated = "NameAr" });
                }
            }
            catch (Exception e)
            {
                Exceptions.ExceptionError.SaveException(e);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });


        }

        [HttpGet("GetRole")]
        public IActionResult GetRole(int CompanyId,string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = RoleService.GetRole(CompanyId);
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