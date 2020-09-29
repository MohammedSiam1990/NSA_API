using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Exceptions;
using ImagesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS.Core.Resources;
using POS.Service.IService;

namespace POS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ItemController : Controller
    {
        private IItemService ItemService;
        private ImagesPath imagesPath;

        public ItemController(IItemService _ItemService, ImagesPath _imagesPath)
        {
            ItemService = _ItemService;
            imagesPath = _imagesPath;
        }

        [AllowAnonymous]
        [HttpGet("GetItems")]
        public IActionResult GetItems(int BrandID,string Lang="en")
        {

            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);


                var data = ItemService.GetItems(BrandID, imagesPath.Item);



                if (data == null)
                {
                    return Ok(new { success = false, message = lang.No_data_available });
                }
                else
                {
                    return Ok(new { success = true, message = "", datalist = data });
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