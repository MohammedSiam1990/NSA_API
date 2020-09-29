using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.API.Models;
using POS.Core.Resources;
using POS.Entities;
using POS.Service.IService;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemUomController : ControllerBase
    {
        private IItemUomService ItemUomService;
        private IMapper Mapper;

        public ItemUomController(
                                      IItemUomService _ItemUomService,
                                      IMapper mapper
                                )
        {
            ItemUomService = _ItemUomService;
            Mapper = mapper;
        }

        [HttpPost("AddItemUom")]
        public IActionResult Add([FromBody]ItemUomModel model , string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
                // map model to entity
                var itemUom = Mapper.Map<ItemUom>(model);

                if (ItemUomService.ValidateitemUom(itemUom))
               
                {
                    if (ItemUomService.ValidateCodeorNameAlreadyExist(model.ItemUomid, model.Name))
                        return Ok(new { success = false, message = lang.English_name_already_exists, repeated = "Name" });

                    if (ItemUomService.ValidateCodeorNameArAlreadyExist(model.ItemUomid, model.NameAr))
                        return Ok(new { success = false, message = lang.Arabic_name_already_exists, repeated = "NameAr" });

                    ItemUomService.AddItemUom(itemUom);
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

        [HttpPost("UpdateItemUom")]
        public IActionResult Update([FromBody]ItemUomModel model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
                // map model to entity
                var itemUom = Mapper.Map<ItemUom>(model);
                if (ItemUomService.ValidateitemUom(itemUom))
               
                {
                    if (ItemUomService.ValidateCodeorNameAlreadyExist(model.ItemUomid, model.Name))
                        return Ok(new { success = false, message = lang.English_name_already_exists, repeated = "Name" });

                    if (ItemUomService.ValidateCodeorNameArAlreadyExist(model.ItemUomid, model.NameAr))
                        return Ok(new { success = false, message = lang.Arabic_name_already_exists, repeated = "NameAr" });

                    ItemUomService.UpdateItemUom(itemUom);
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

        [HttpGet("GetItemUom")]
        public IActionResult GetItemUom(long ItemUomid, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var ItemUom = ItemUomService.GetItemUom(ItemUomid);
                var data = Mapper.Map<ItemUomModel>(ItemUom);

                if (data == null)
                    return Ok(new { success = true, message = lang.No_data_available, datalist = data });
                else
                    return Ok(new { success = true, message = "", datalist = data });

            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        
    }

        [HttpGet("GetItemUoms")]
        public IActionResult GetItemUoms(string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var ItemUoms = ItemUomService.GetItemUoms();
                var data = Mapper.Map<List<ItemUomModel>>(ItemUoms);

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
    }
}