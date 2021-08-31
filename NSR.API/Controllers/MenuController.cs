using AutoMapper;
using Exceptions;
using ImagesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSR.API.Models;
using NSR.Core.Resources;
using NSR.Service.IService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace NSR.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private ImagesPath imagesPath;
        private IMenuService MenuService;

        private IMapper Mapper;

        public MenuController(
                                      IMenuService _MenuService,
                                      ImagesPath _imagesPath,
                                      IMapper mapper
                                )
        {
            MenuService = _MenuService;
            imagesPath = _imagesPath;
            Mapper = mapper;

        }

        [HttpGet("GetMenu")]
        public IActionResult GetMenu(string Lang = "en")
        {

            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
                var Model = MenuService.GetMenu();
                var data = Mapper.Map<List<MenuModel>>(Model);
                if (data != null)
                {
                    if (data.Count() == 0)
                    {
                        return Ok(new { success = true, message = lang.No_data_available, datalist = data });
                    }
                    else
                    {
                        return Ok(new { success = true, message = "", datalist = data });
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

