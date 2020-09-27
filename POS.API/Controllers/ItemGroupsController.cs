using AutoMapper;
using Exceptions;
using ImagesService;
using Microsoft.AspNetCore.Mvc;
using POS.API.Models;
using POS.Core.Resources;
using POS.Entities;
using POS.Service.IService;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace POS.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ItemGroupsController : ControllerBase
    {
        private ImagesPath imagesPath;
        private IItemGroupsService itemGroupsService;

        private IMapper Mapper;

        public ItemGroupsController(
                                      IItemGroupsService _itemGroupsService,
                                      ImagesPath _imagesPath,
                                      IMapper mapper
                                )
        {
            itemGroupsService = _itemGroupsService;
            imagesPath = _imagesPath;
            Mapper = mapper;

        }

        [HttpGet("GetItemGroups")]
        public IActionResult GetItemGroups(int BrandID, string Lang = "en")
        {

            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);


                var data = itemGroupsService.GetProcItemGroups(BrandID, imagesPath.ItemGroup);

                if (data != null)
                {
                    if (data.Count() == 0)
                    {
                        return Ok(new { success = true, message = lang.No_data_available, datalist = data.ToList() });
                    }
                    else
                    {
                        return Ok(new { success = true, message = "", datalist = data.ToList() });
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


        [HttpPost("SaveItemGroups")]
        public IActionResult SaveItemGroups(ItemGroupsModel model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var ItemGroup = Mapper.Map<ItemGroup>(model);

                var data = itemGroupsService.SaveItemGroup(ItemGroup);

                if (data != 1)
                {
                    if (data == -1)
                    {
                        return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

                    }

                    if (data == -2)
                    {
                        return Ok(new { success = false, message = lang.English_name_already_exists, repeated = "ItemGroupName" });
                    }
                    if (data == -3)
                    {
                        return Ok(new { success = false, message = lang.Arabic_name_already_exists, repeated = "ItemGroupNameAr" });
                    }
                    if (data == -4)
                    {
                        return Ok(new { success = false, message = lang.English_group_name_for_mobile_already_exists, repeated = "ItemGroupMobileName" });
                    }
                    if (data == -5)
                    {
                        return Ok(new { success = false, message = lang.Arabic_group_name_for_mobile_already_exists, repeated = "ItemGroupMobileNameAr" });
                    }
                }
                else
                {
                    return Ok(new { success = true, message = lang.Saved_successfully_completed });
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

