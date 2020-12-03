using AutoMapper;
using Exceptions;
using ImagesService;
using Microsoft.AspNetCore.Mvc;
using POS.Core.Resources;
using POS.Entities;
using POS.Models;
using POS.Service.IService;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace POS.API.CORE.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MajorServicesController : ControllerBase
    {

        private ImagesPath imagesPath;

        private IMajorServicesService MajorServicesService;
        private IMapper Mapper;

        public MajorServicesController(
            IMajorServicesService _MajorServicesService,
            ImagesPath _imagesPath,
            IMapper mapper)
        {
            MajorServicesService = _MajorServicesService;
            Mapper = mapper;
            imagesPath = _imagesPath;
        }


        [HttpPost("AddMajorServices")]
        public IActionResult Add([FromBody]MajorServicesModel model, string Lang = "en")
        {
            // map model to entity
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

            var MajorServices = Mapper.Map<MajorServices>(model);
            try
            {
                // if (MajorServicesService.ValidateMajorServices(MajorServices))
                // create MajorServices
                {
                    MajorServicesService.AddMajorServices(MajorServices);
                    return Ok(new { message = lang.Saved_successfully_completed });
                }

                //  return Ok(new { message = "Data is Not Complete" });
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

        [HttpPost("UpdateMajorServices")]
        public IActionResult Update([FromBody]MajorServicesModel model, string Lang = "en")
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

            // map model to entity
            var MajorServices = Mapper.Map<MajorServices>(model);
            try
            {
                // if (MajorServicesService.ValidateMajorServices(MajorServices))
                // Edit MajorServices
                {
                    MajorServicesService.UpdateMajorServices(MajorServices);
                    return Ok(new { success = true, message = lang.Updated_successfully_completed });
                }


                //  return Ok(new { success = false, message = lang.Update_operation_failed });
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

        [HttpPost("DeleteMajorServices")]
        public IActionResult Delete(int MajorServicesId)
        {

            try
            {
                MajorServicesService.DeleteMajorServices(MajorServicesId);
                return Ok(new { message = lang.Deleted_successfully });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }


        [HttpGet("GetMajorServicesById")]
        public IActionResult GetMajorServicesById(int MajorServicesId)
        {
            try
            {
                // create user
                var MajorServices = MajorServicesService.GetMajorService(MajorServicesId);
                var MajorServicesDto = Mapper.Map<MajorServicesModel>(MajorServices);
                //   MajorServicesDto.ImageName = imagesPath.Comapny + MajorServicesDto.ImageName;

                return Ok(new { datalist = MajorServicesDto, message = "", success = true });
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

        [HttpGet("GetMajorServices")]
        public IActionResult GetMajorServices(string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = MajorServicesService.GetMajorServices();
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
                ExceptionError.SaveException(ex);
            }

            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

    }
}

