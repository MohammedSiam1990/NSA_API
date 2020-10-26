using AutoMapper;
using Exceptions;
using ImagesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pos.IService;
using POS.API.Models;
using POS.Core.Resources;
using POS.Data.Entities;
using POS.Entities;
using POS.Models;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace POS.API.CORE.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private ImagesPath imagesPath;
        private IItemService ItemService;
        private IMapper Mapper;
        private IItemComponentsService ItemComponentsService;
        public ItemController(
                                      IItemService _ItemService,
                                       ImagesPath _imagesPath,
                                      IMapper mapper,
                                      IItemComponentsService _ItemComponentsService
                                )
        {
            ItemService = _ItemService;
            imagesPath = _imagesPath;
            Mapper = mapper;
            ItemComponentsService = _ItemComponentsService;
        }

        [AllowAnonymous]
        [HttpGet("GetItems")]
        public IActionResult GetItems(int BrandID, string Lang = "en")
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
                    return Ok(new { success = true, message = "", datalist = JsonConvert.DeserializeObject(data) });
                }
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);

            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });


        }

        [AllowAnonymous]
        [HttpGet("GetUOMNames")]
        public IActionResult GetUOMNames(int BrandID, string Lang = "en")
        {

            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);


                var data = ItemService.GetUOMName(BrandID);



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


        [HttpPost("SaveItem")]
        public IActionResult SaveItem(ItemModel model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var Item = Mapper.Map<Item>(model);


                int ItemData = ItemService.ValidateItemAlreadyExist(Item);

                if (ItemData == 1)
                {
                    string SkuAlert;
                    var skuId = ItemService.ValidateSkuAlreadyExist(Lang, Item, out SkuAlert);
                    if (skuId != -7)
                    {
                        if (Item.ItemId == 0)
                            ItemService.AddItem(Item);
                        else
                        {
                            ItemService.DeleteSku(Item.ItemId);
                            ItemService.UpdateItem(Item);
                        }
                        return Ok(new { success = true, message = lang.Saved_successfully_completed });
                    }
                    else
                        return Ok(new { success = false, message = lang.Barcode_already_exists, repeated = SkuAlert });
                }
                else if (ItemData == -1)
                    return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
                else if (ItemData == -2)
                    return Ok(new { success = false, message = lang.English_name_already_exists, repeated = "ItemName" });
                else if (ItemData == -3)
                    return Ok(new { success = false, message = lang.Arabic_name_already_exists, repeated = "ItemNameAr" });
                else if (ItemData == -4)
                    return Ok(new { success = false, message = lang.English_name_already_exists, repeated = "MobilName" });
                else if (ItemData == -5)
                    return Ok(new { success = false, message = lang.Arabic_name_already_exists, repeated = "MobilNameAr" });
                else if (ItemData == -6)
                    return Ok(new { success = false, message = lang.Code_already_exists, repeated = "ItemNum" });

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
                // return error message if there was an exception

            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }


        [HttpPost("SaveItemComponents")]
        public IActionResult SaveItemComponents(List<ItemComponentsModel> model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                for(int i = 0; i < model.Count; ++i)
                {
                    var ItemCom = Mapper.Map<ItemComponents>(model[i]);


                    if (ItemCom.ItemComponentID == 0)
                        ItemComponentsService.AddItemComponents(ItemCom);
                    else
                    {
                        ItemComponentsService.DeleteItemComponents(ItemCom.ItemComponentID);
                        ItemComponentsService.AddItemComponents(ItemCom);
                    }

                }
                return Ok(new { success = true, message = lang.Saved_successfully_completed });

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
