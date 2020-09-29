using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS.Core.Resources;
using POS.Service.IService;

namespace POS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ItemsController : Controller
    {
        private IItemService ItemService;

        public ItemsController(IItemService _ItemService)
        {
            ItemService = _ItemService;
        }

        [AllowAnonymous]
        [HttpGet("GetItem")]
        public IActionResult GetItem(int BrandID, string ImageURL,string Lang="en")
        {

            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);


                var data = ItemService.GetItems(BrandID, ImageURL);

                if (data == null)
                {
                    return Ok(new { success = false, message = lang.No_data_available });
                }
                else
                {
                    return Ok(new { success = true, message = "", datalist = JsonConvert.DeserializeObject(data) });
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