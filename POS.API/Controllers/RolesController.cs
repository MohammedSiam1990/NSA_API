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
using POS.Core.Resources;
using POS.Data.Dto.Account;
using POS.Entities;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<AspNetRoles> roleManager;

        public RolesController(RoleManager<AspNetRoles> _roleManager)
        {
            roleManager = _roleManager;
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(AspNetRoles role, string Lang = "en")
        {

            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

            var roleExist = await roleManager.RoleExistsAsync(role.Name);
            if (!roleExist)
            {
                
                var result = await roleManager.CreateAsync(role);
            }
            return Ok();

        }

    }
}