using AutoMapper;
using Exceptions;
using ImagesService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSR.API.Models;
using NSR.Common;
using NSR.Core.Resources;
using NSR.Entities;
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
    public class ApproveRejectSchoolController : ControllerBase
    {

        private ImagesPath imagesPath;
        private ISchoolService SchoolService;
        private IMapper Mapper;

        public ApproveRejectSchoolController(
            ISchoolService _SchoolService,
            ImagesPath _imagesPath,
            IMapper mapper)
        {

            SchoolService = _SchoolService;
            Mapper = mapper;
            imagesPath = _imagesPath;
        }





        [HttpPost("DeleteSchool")]
        public IActionResult Delete(int SchoolId)
        {

            try
            {
                SchoolService.DeleteSchool(SchoolId);
                return Ok(new { message = lang.Deleted_successfully });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }
        [HttpPost("SaveSchool")]
        public IActionResult SaveSchool(SchoolModel model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var School = Mapper.Map<School>(model);
                var ExistModel = SchoolService.ValidateAlreadyExist(School);
                if (ExistModel != null)
                {
                    string SchoolAlert;
                    if (School.SchoolName1 == ExistModel.SchoolName1)
                    {
                        SchoolAlert = " , SchoolName1 : " + ExistModel.SchoolName1;
                        return Ok(new { success = false, message = lang.English_name_already_exists + SchoolAlert });
                    }
                    else if (School.SchoolName2 == ExistModel.SchoolName2)
                    {
                        SchoolAlert = " , SchoolName2 : " + ExistModel.SchoolName2;
                        return Ok(new { success = false, message = lang.English_name_already_exists + SchoolAlert });
                    }
                    else if (School.SchoolName3 == ExistModel.SchoolName3)
                    {
                        SchoolAlert = " , SchoolName3 : " + ExistModel.SchoolName3;
                        return Ok(new { success = false, message = lang.English_name_already_exists + SchoolAlert });
                    }
                    else if (School.SchoolName4 == ExistModel.SchoolName4)
                    {
                        SchoolAlert = " , SchoolName4 : " + ExistModel.SchoolName4;
                        return Ok(new { success = false, message = lang.English_name_already_exists + SchoolAlert });
                    }
                    else
                    {
                        SchoolAlert = " , SchoolNameEN : " + ExistModel.SchoolNameEN;
                        return Ok(new { success = false, message = lang.Arabic_name_already_exists + SchoolAlert });
                    }
                }
                int result = SchoolService.SaveSchool(School, imagesPath.NSR + "nsf2-logo.svg");
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

        [HttpGet("GetSchoolById")]
        public IActionResult GetSchoolById(int InsertedBy, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
                var School = SchoolService.GetSchool(InsertedBy);
                var SchoolDto = Mapper.Map<SchoolModel>(School);





                if (SchoolDto != null)
                {
                    return Ok(new
                    {
                        datalist = SchoolDto,
                        img_url_Passport = imagesPath.School + SchoolDto.ImageName_Passport,
                        img_url_workletter_MinistryDevelopment = imagesPath.School + SchoolDto.ImageName_workletter_MinistryDevelopment,
                        img_url_Certificates = imagesPath.School + SchoolDto.ImageName_Certificates,
                        img_url_person = imagesPath.School + SchoolDto.ImageName_person,
                        img_url_QID = imagesPath.School + SchoolDto.ImageName_QID,
                        img_url_Health = imagesPath.School + SchoolDto.ImageName_Health,
                        img_url_married = imagesPath.School + SchoolDto.ImageName_married,
                        img_url_other = imagesPath.School + SchoolDto.ImageName_other,
                        message = "",
                        success = true
                    });
                }
                else
                {
                    return Ok(new
                    {
                        datalist = SchoolDto,
                        img_url_Passport = "",
                        img_url_workletter_MinistryDevelopment = "",
                        img_url_Certificates = "",
                        img_url_person = "",
                        img_url_QID = "",
                        img_url_Health = "",
                        img_url_married = "",
                        img_url_other = "",
                        message = "",
                        success = true
                    });
                }


            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

        [HttpGet("GetProSchoolsAll")]
        public IActionResult GetProSchoolsAll(string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = SchoolService.GetProSchoolsAll();
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
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }


    }
}

