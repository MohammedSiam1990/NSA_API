using AutoMapper;
using Exceptions;
using ImagesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pos.IService;
using POS.Core.Resources;
using POS.Entities;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace POS.API.CORE.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MajorServicesIconsController : ControllerBase
    {

        private ImagesPath imagesPath;

        private IMajorServicesIconsService MajorServicesIconsService;
        private IMapper Mapper;

        public MajorServicesIconsController(
            IMajorServicesIconsService _MajorServicesIconsService,
            ImagesPath _imagesPath,
            IMapper mapper)
        {
            MajorServicesIconsService = _MajorServicesIconsService;
            Mapper = mapper;
            imagesPath = _imagesPath;
        }


        [HttpPost("AddMajorServicesIcons")]
        public IActionResult Add([FromBody]MajorServicesIconsModel model, string Lang = "en")
        {
            // map model to entity
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

            var MajorServicesIcons = Mapper.Map<MajorServicesIcons>(model);
            try
            {
               // if (MajorServicesIconsService.ValidateMajorServicesIcons(MajorServicesIcons))
                // create MajorServicesIcons
                {
                    MajorServicesIconsService.AddMajorServicesIcons(MajorServicesIcons);
                    return Ok(new { message = "Add MajorServicesIcons Success" });
                }

                return Ok(new { message = "Data is Not Complete" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }


        [HttpPost("UpdateMajorServicesIcons")]
        public IActionResult Update([FromBody]MajorServicesIconsModel model, string Lang = "en")
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

            // map model to entity
            var MajorServicesIcons = Mapper.Map<MajorServicesIcons>(model);
            try
            {
               // if (MajorServicesIconsService.ValidateMajorServicesIcons(MajorServicesIcons))
                // Edit MajorServicesIcons
                {
                    MajorServicesIconsService.UpdateMajorServicesIcons(MajorServicesIcons);
                    return Ok(new { success = true, message = lang.Updated_successfully_completed });
                }


                return Ok(new { success = false, message = lang.Update_operation_failed });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

        [HttpPost("DeleteMajorServicesIcons")]
        public IActionResult Delete(int MajorServicesIconsId)
        {

            try
            {
                MajorServicesIconsService.DeleteMajorServicesIcons(MajorServicesIconsId);
                return Ok(new { message = "Delete MajorServicesIcons Success" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return Ok(new { message = ex.Message });
            }
        }


        [HttpGet("GetMajorServicesIcons")]
        public IActionResult GetMajorServicesIcons(int MajorServicesIconsId)
        {
            try
            {
                // create user
                var MajorServicesIcons = MajorServicesIconsService.GetMajorServicesIcons(MajorServicesIconsId);
                var MajorServicesIconsDto = Mapper.Map<MajorServicesIconsModel>(MajorServicesIcons);
          
                return Ok(new { datalist = MajorServicesIconsDto, message = "", success = true });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

        [HttpGet("GetMajorServicesIcons")]
        public IActionResult GetMajorServicesIcons(string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = MajorServicesIconsService.GetMajorServicesIcons();
                if (data != null)
                {
                    if (data.Count() == 0)
                    {
                        return Ok(new { success = true, message = lang.No_data_available, datalist = JsonConvert.DeserializeObject(data) });
                    }
                    else
                    {
                        return Ok(new { success = true, message = "", datalist = JsonConvert.DeserializeObject(data) });
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

