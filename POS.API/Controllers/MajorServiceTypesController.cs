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
using POS.Service.IService;
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
    public class MajorServiceTypesController : ControllerBase
    {

        private ImagesPath imagesPath;

        private IMajorServiceTypesService MajorServiceTypesService;
        private IMapper Mapper;

        public MajorServiceTypesController(
            IMajorServiceTypesService _MajorServiceTypesService,
            ImagesPath _imagesPath,
            IMapper mapper)
        {
            MajorServiceTypesService = _MajorServiceTypesService;
            Mapper = mapper;
            imagesPath = _imagesPath;
        }


        [HttpPost("AddMajorServiceTypes")]
        public IActionResult Add([FromBody]List<MajorServiceTypesModel> model, string Lang = "en")
        {
            // map model to entity
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

            var MajorServiceTypes = Mapper.Map<List<MajorServiceTypes>>(model);
            try
            {
               // if (MajorServiceTypesService.ValidateMajorServiceTypes(MajorServiceTypes))
                // create MajorServiceTypes
                {
                    MajorServiceTypesService.AddMajorServiceTypes(MajorServiceTypes);
                    return Ok(new { message =lang.Saved_successfully_completed});
                }

              //  return Ok(new { message = "Data is Not Complete" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

        [HttpPost("UpdateMajorServiceTypes")]
        public IActionResult Update([FromBody]List<MajorServiceTypesModel> model, string Lang = "en")
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

            var MajorServiceTypes = Mapper.Map<List<MajorServiceTypes>>(model);
            try
            {
               // if (MajorServiceTypesService.ValidateMajorServiceTypes(MajorServiceTypes))
                // Edit MajorServiceTypes
                {
                    MajorServiceTypesService.UpdateMajorServiceTypes(MajorServiceTypes);
                    return Ok(new { success = true, message = lang.Updated_successfully_completed });
                }


              //  return Ok(new { success = false, message = lang.Update_operation_failed });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

        [HttpPost("DeleteMajorServiceTypes")]
        public IActionResult Delete(int MajorServiceTypesId)
        {

            try
            {
                MajorServiceTypesService.DeleteMajorServiceTypes(MajorServiceTypesId);
                return Ok(new { message = lang.Deleted_successfully });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return Ok(new { message = ex.Message });
            }
        }
        [HttpPost("SaveMajorServiceTypes")]
        public IActionResult SaveMajorServiceTypes(List<MajorServiceTypes> model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                //var Customer = Mapper.Map<list>(model);

                int result = MajorServiceTypesService.SaveMajorServiceTypes(model);
                if (result == 1)
                {
                    return Ok(new { success = true, message = lang.Saved_successfully_completed });

                }
                else
                {
                    return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
                }
            }
            catch (Exception ex)
            {

                ExceptionError.SaveException(ex);
                // return error message if there was an exception

            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }

        [HttpGet("GetMajorServiceTypesById")]
        public IActionResult GetMajorServiceTypesById(int MajorServiceTypesId)
        {
            try
            {
                // create user
                var MajorServiceTypes = MajorServiceTypesService.GetMajorServiceTypes(MajorServiceTypesId);
                var MajorServiceTypesDto = Mapper.Map<MajorServiceTypesModel>(MajorServiceTypes);
             //   MajorServiceTypesDto.ImageName = imagesPath.Comapny + MajorServiceTypesDto.ImageName;

                return Ok(new { datalist = MajorServiceTypesDto, message = "", success = true });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

        [HttpGet("GetMajorServiceTypes")]
        public IActionResult GetMajorServiceTypes(string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = MajorServiceTypesService.GetMajorServiceTypes();
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
                // return error message if there was an exception
                ExceptionError.SaveException(ex);

            }

            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

    }
}

