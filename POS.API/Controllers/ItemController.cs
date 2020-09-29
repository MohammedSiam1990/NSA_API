﻿using AutoMapper;
using Exceptions;
using ImagesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pos.IService;
using POS.API.Models;
using POS.Core.Resources;
using POS.Entities;
using POS.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace POS.API.CORE.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private ImagesPath imagesPath;
        private IItemService ItemService;

        private IMapper Mapper;

        public ItemController(
                                      IItemService _ItemService,
                                       ImagesPath _imagesPath,
                                      IMapper mapper
                                )
        {
            ItemService = _ItemService;
            imagesPath = _imagesPath;
            Mapper = mapper;

        }



        [HttpGet("GetItemAll")]
        public IActionResult GetItemAll(string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = ItemService.GetItemAll();//BrandID, imagesPath.Item
                if (data != null)
                {
                    if (data.Count() == 0)
                    {
                        return Ok(new { success = true, message = lang.No_data_available , datalist = data.ToList() });
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

        [HttpGet("GetItem")]
        public IActionResult GetItemAll(string Lang = "en",long ItemId )
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = ItemService.GetItem(ItemId);//BrandID, imagesPath.Item
                if (data != null)
                {
                    if (data == null)
                    {
                        return Ok(new { success = true, message = lang.No_data_available , datalist = data });
                    }
                    else
                    {
                        return Ok(new { success = true, message = "", datalist = data });
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
        [HttpPost("SaveItem")]
        public IActionResult SaveItem(ItemModel model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var Item = Mapper.Map<Item>(model);

                
                int data = ItemService.ValidateNameAlreadyExist(Item); 
                if (data != 1)
                {
                    if (data == -1)
                        return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
                    else if (data == -2)
                        return Ok(new { success = false, message = lang.English_name_already_exists, repeated = "ItemName" });
                    else if (data == -3)
                        return Ok(new { success = false, message = lang.Arabic_name_already_exists, repeated = "ItemNameAr" });
                    else if (data == -4)
                        return Ok(new { success = false, message = lang.English_name_already_exists, repeated = "MobilName" });
                    else if (data == -5)
                        return Ok(new { success = false, message = lang.Arabic_name_already_exists, repeated = "MobilNameAr" });
                }
                else
                {
                    if (Item.ItemId == 0)
                    ItemService.AddItem(Item);
                    else
                    ItemService.UpdateItem(Item);
                    return Ok(new { success = true, message = lang.Saved_successfully_completed });
                }

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
                // return error message if there was an exception

            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }
    }
}
