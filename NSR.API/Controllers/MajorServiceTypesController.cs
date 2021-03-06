using AutoMapper;
using Exceptions;
using ImagesService;
using Microsoft.AspNetCore.Mvc;
using NSR.Common;
using NSR.Core.Resources;
using NSR.Entities;
using NSR.Models;
using NSR.Service.IService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace NSR.API.CORE.Controllers
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

            try
            {
                string ParamName;

                var MajorServiceTypes = Mapper.Map<List<MajorServiceTypes>>(model);
                foreach (var item in MajorServiceTypes)
                {
                    bool valid = CommandTextValidator.ValidateStatement(out ParamName, item.TypeName, item.TypeNameAr);
                    if (valid == false)
                    {
                        return Ok(new { success = false, Name = ParamName, message = lang.Please_Remove_special_characters });
                    }

                    item.StatusId = 7;
                    var ExistModel = MajorServiceTypesService.ValidateAlreadyExist(item);
                    if (ExistModel != null)
                    {
                        string ServiceTypesAlert;
                        if (item.TypeName == ExistModel.TypeName)
                        {
                            ServiceTypesAlert = " , TypeName : " + ExistModel.TypeName;
                            return Ok(new { success = false, message = lang.English_name_already_exists + ServiceTypesAlert });
                        }
                        else
                        {
                            ServiceTypesAlert = " , TypeNameAr : " + ExistModel.TypeNameAr;
                            return Ok(new { success = false, message = lang.Arabic_name_already_exists + ServiceTypesAlert });
                        }
                    }
                }
                MajorServiceTypesService.AddMajorServiceTypes(MajorServiceTypes);
                return Ok(new { message = lang.Saved_successfully_completed });
            }
            catch (Exception ex)
            {
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

                foreach (var item in MajorServiceTypes)
                {
                    item.StatusId = 7;
                    var ExistModel = MajorServiceTypesService.ValidateAlreadyExist(item);
                    if (ExistModel != null)
                    {
                        string ServiceTypesAlert;
                        if (item.TypeName == ExistModel.TypeName)
                        {
                            ServiceTypesAlert = " , TypeName : " + ExistModel.TypeName;
                            return Ok(new { success = false, message = lang.English_name_already_exists + ServiceTypesAlert });
                        }
                        else
                        {
                            ServiceTypesAlert = " , TypeNameAr : " + ExistModel.TypeNameAr;
                            return Ok(new { success = false, message = lang.Arabic_name_already_exists + ServiceTypesAlert });
                        }
                    }
                }

                MajorServiceTypesService.UpdateMajorServiceTypes(MajorServiceTypes);
                return Ok(new { success = true, message = lang.Updated_successfully_completed });



                //  return Ok(new { success = false, message = lang.Update_operation_failed });
            }
            catch (Exception ex)
            {
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
                ExceptionError.SaveException(ex);
                return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

            }
        }
        [HttpPost("SaveMajorServiceTypes")]
        public IActionResult SaveMajorServiceTypes(List<MajorServiceTypesModel> model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var MajorServiceTypes = Mapper.Map<List<MajorServiceTypes>>(model);

                foreach (var item in MajorServiceTypes)
                {
                    item.StatusId = 7;
                    var ExistModel = MajorServiceTypesService.ValidateAlreadyExist(item);
                    if (ExistModel != null)
                    {
                        string ServiceTypesAlert;
                        if (item.TypeName == ExistModel.TypeName)
                        {
                            ServiceTypesAlert = " , TypeName : " + ExistModel.TypeName;
                            return Ok(new { success = false, message = lang.English_name_already_exists + ServiceTypesAlert });
                        }
                        else
                        {
                            ServiceTypesAlert = " , TypeNameAr : " + ExistModel.TypeNameAr;
                            return Ok(new { success = false, message = lang.Arabic_name_already_exists + ServiceTypesAlert });
                        }
                    }
                }
                int result = MajorServiceTypesService.SaveMajorServiceTypes(MajorServiceTypes);
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
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }

        [HttpGet("GetMajorServiceTypesById")]
        public IActionResult GetMajorServiceTypesById(int MajorServiceId, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
                var MajorServiceTypes = MajorServiceTypesService.GetMajorServiceTypes(MajorServiceId);
                var MajorServiceTypesDto = Mapper.Map<List<MajorServiceTypesModel>>(MajorServiceTypes);
                //   MajorServiceTypesDto.ImageName = imagesPath.Comapny + MajorServiceTypesDto.ImageName;

                return Ok(new { datalist = MajorServiceTypesDto, message = "", success = true });
            }
            catch (Exception ex)
            {
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

                var MajorServiceTypes = MajorServiceTypesService.GetMajorServiceTypes();
                var MajorServiceTypesDto = Mapper.Map<List<MajorServiceTypesModel>>(MajorServiceTypes);
                if (MajorServiceTypesDto != null)
                {
                    if (MajorServiceTypesDto.Count() == 0)
                    {
                        return Ok(new { success = true, message = lang.No_data_available, datalist = MajorServiceTypesDto });
                    }
                    else
                    {
                        return Ok(new { success = true, message = "", datalist = MajorServiceTypesDto });
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

