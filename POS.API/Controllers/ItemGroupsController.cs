using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using POS.API.Models;
using POS.Entities;
using POS.Service.IService;
using POS.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ItemGroupsController : ControllerBase
    {

        private IItemGroupsService itemGroupsService;

        private IMapper Mapper;

        public ItemGroupsController(
                                      IItemGroupsService _itemGroupsService,
                                      IMapper mapper
                                )
        {
            itemGroupsService = _itemGroupsService;
            Mapper = mapper;

        }

        [HttpGet("GetProcItemGroups")]
        public IActionResult GetProcItemGroups(int BrandID, string ImageName)
        {
          
            try
            {
                var data = itemGroupsService.GetProcItemGroups(BrandID, ImageName);

                if (data!= null)
                {
                    if (data.Count() == 0)
                    {
                        return Ok(new { success = true, message = Resources.lang.No_data_available, datalist = data.ToList() });
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
                return BadRequest(new { message = ex.Message + " " + Resources.lang.An_error_occurred_while_processing_your_request });
            }
            
                return Ok(new { success = false, message = Resources.lang.No_data_available  });
        }


        [HttpPost("SaveProcItemGroup")]
        public  IActionResult SaveProcItemGroup(ItemGroupsModel model)
        {
            try
            {

                var ItemGroup = Mapper.Map<ItemGroup>(model);
               
                var data  = itemGroupsService.SaveItemGroup(ItemGroup);

                if (data != 1)
                {
                    if (data == -2)
                    {
                        return Ok( new { success = false, message = Resources.lang.English_name_already_exists, repeated = "en" });
                    }
                    if (data == -3)
                    {
                        return Ok(new { success = false, message = Resources.lang.Arabic_name_already_exists, repeated = "ar" });
                    }
                    if (data == -4)
                    {
                        return Ok(new { success = false, message =Resources.lang.English_group_name_for_mobile_already_exists, repeated = "en2" });
                    }
                    if (data == -5)
                    {
                        return Ok(new { success = false, message = Resources.lang.Arabic_group_name_for_mobile_already_exists, repeated = "ar2" });
                    }
                }
                else
                {
                    return Ok(new { success = true, message = Resources.lang.Saved_successfully_completed });
                }

            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message + " " + Resources.lang.An_error_occurred_while_processing_your_request });
            }
           return Ok(new { success = false + Resources.lang.An_error_occurred_while_processing_your_request });

        }
    }

}

