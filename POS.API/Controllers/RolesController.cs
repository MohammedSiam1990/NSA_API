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

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<AspNetRoles> roleManager;
        private UserManager<POS.Data.ApplicationUser> userManger;
        private IAccountService _accountService;

        public RolesController(RoleManager<AspNetRoles> _roleManager, UserManager<POS.Data.ApplicationUser> _userManger, IAccountService accountService)
        {
            roleManager = _roleManager;
            userManger = _userManger;
            _accountService = accountService;
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(AspNetRoles role, string Lang = "en")
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
            try
            {
                var roleExist = await roleManager.RoleExistsAsync(role.Name);
                if (!roleExist)
                {
                    var result = await roleManager.CreateAsync(role);
                }
                return Ok();

            }
            catch (Exception e)
            {
                return Ok(new { success = false, message = e });

            }

        }


        [HttpPost("AssginRole")]
        
        public async Task<IActionResult> AssginRole(string UserID, string RoleID, string Lang = "en")
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
            try
            {
                var user = await userManger.FindByIdAsync(UserID);
                var role = await roleManager.FindByIdAsync(RoleID);
                //var userRole = new ApplicationUser()
                //{
                //    Id = user.Id
                //};
                var result = await userManger.AddToRoleAsync(user, role.Name);
                if (result.Succeeded)
                {
                    return Ok(new { success = true, message = "AssginRole success" });
                }
                return Ok(new { success = false });


            }
            catch (Exception e)
            {
                return Ok(new { success = false, message = e });

            }
        }



    }
}