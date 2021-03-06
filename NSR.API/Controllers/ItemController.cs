using AutoMapper;
using Exceptions;
using ImagesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSR.IService;
using NSR.API.Models;
using NSR.Common;
using NSR.Core.Resources;
using NSR.Data.Entities;
using NSR.Entities;
using NSR.Service.IService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace NSR.API.CORE.Controllers
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
        private ISalesGroupsItemsService SalesGroupsItemsService;
        public ItemController(
                                      IItemService _ItemService,
                                       ImagesPath _imagesPath,
                                      IMapper mapper,
                                      IItemComponentsService _ItemComponentsService,
                                      ISalesGroupsItemsService _SalesGroupsItemsService
                                )
        {
            ItemService = _ItemService;
            imagesPath = _imagesPath;
            Mapper = mapper;
            ItemComponentsService = _ItemComponentsService;
            SalesGroupsItemsService = _SalesGroupsItemsService;
        }

        [AllowAnonymous]
        [HttpGet("GetItems")]
        public IActionResult GetItems(int BrandID, string Lang = "en")
        {

            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = ItemService.GetItems(BrandID, imagesPath.Item, Lang);
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
        [HttpGet("GetActiveItems")]
        public IActionResult GetActiveItems(int BrandID, string Lang = "en")
        {

            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = ItemService.GetActiveItems(BrandID, imagesPath.Item, Lang);
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
                string ParamName;
                bool valid = CommandTextValidator.ValidateStatement(out ParamName, model.ItemName, model.ItemNameAr,model.ItemNum,model.MobileName,model.MobileNameAr);
                if (valid == false)
                {
                    return Ok(new { success = false, Name = ParamName, message = lang.Please_Remove_special_characters });
                }

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
                        return Ok(new { success = false, message = SkuAlert });
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
                    return Ok(new { success = false, message = lang.Number_already_exists, repeated = "ItemNum" });

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }


        [HttpPost("SaveItemComponents")]
        public IActionResult SaveItemComponents(List<ItemComponents> model, int MainItemID, int MainItemUOMID, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                ItemComponentsService.SaveItemComponents(model, MainItemID, MainItemUOMID);
                return Ok(new { success = true, message = lang.Saved_successfully_completed });

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }


        [HttpPost("SaveSalesGroupsItems")]
        public IActionResult SaveSalesGroupsItems(List<SalesGroupsItems> model, int SalesGroupID, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                SalesGroupsItemsService.SaveSalesGroupsItems(model, SalesGroupID);
                return Ok(new { success = true, message = lang.Saved_successfully_completed });

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }



    }
}
