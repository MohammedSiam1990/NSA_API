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
    public class ApproveRejectUniversityController : ControllerBase
    {

        private ImagesPath imagesPath;
        private IUniversityService UniversityService;
        private IMapper Mapper;

        public ApproveRejectUniversityController(
            IUniversityService _UniversityService,
            ImagesPath _imagesPath,
            IMapper mapper)
        {
           
            UniversityService = _UniversityService;
            Mapper = mapper;
            imagesPath = _imagesPath;
        }


     
         

        [HttpPost("DeleteUniversity")]
        public IActionResult Delete(int UniversityId)
        {

            try
            {
                UniversityService.DeleteUniversity(UniversityId);
                return Ok(new { message = lang.Deleted_successfully });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }
        [HttpPost("SaveUniversity")]
        public IActionResult SaveUniversity(UniversityModel model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var University = Mapper.Map<University>(model);
                var ExistModel = UniversityService.ValidateAlreadyExist(University);
                if (ExistModel != null)
                {
                    string UniversityAlert;
                    if (University.UniversityName1 == ExistModel.UniversityName1)
                    {
                        UniversityAlert = " , UniversityName1 : " + ExistModel.UniversityName1;
                        return Ok(new { success = false, message = lang.English_name_already_exists + UniversityAlert });
                    }
                    else if (University.UniversityName2 == ExistModel.UniversityName2)
                    {
                        UniversityAlert = " , UniversityName2 : " + ExistModel.UniversityName2;
                        return Ok(new { success = false, message = lang.English_name_already_exists + UniversityAlert });
                    }
                    else if (University.UniversityName3 == ExistModel.UniversityName3)
                    {
                        UniversityAlert = " , UniversityName3 : " + ExistModel.UniversityName3;
                        return Ok(new { success = false, message = lang.English_name_already_exists + UniversityAlert });
                    }
                    else if (University.UniversityName4 == ExistModel.UniversityName4)
                    {
                        UniversityAlert = " , UniversityName4 : " + ExistModel.UniversityName4;
                        return Ok(new { success = false, message = lang.English_name_already_exists + UniversityAlert });
                    }
                    else
                    {
                        UniversityAlert = " , UniversityNameEN : " + ExistModel.UniversityNameEN;
                        return Ok(new { success = false, message = lang.Arabic_name_already_exists + UniversityAlert });
                    }
                }
                int result = UniversityService.SaveUniversity(University, imagesPath.NSR + "nsf2-logo.svg");
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

        [HttpGet("GetUniversityById")]
        public IActionResult GetUniversityById(int InsertedBy, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
                var University = UniversityService.GetUniversity(InsertedBy);
                var UniversityDto = Mapper.Map<UniversityModel>(University);





                if (UniversityDto != null )
                {
                    return Ok(new
                    {
                        datalist = UniversityDto,
                        img_url_Passport = imagesPath.University + UniversityDto.ImageName_Passport,
                        img_url_workletter_MinistryDevelopment = imagesPath.University + UniversityDto.ImageName_workletter_MinistryDevelopment,
                        img_url_Certificates = imagesPath.University + UniversityDto.ImageName_Certificates,
                        img_url_person = imagesPath.University + UniversityDto.ImageName_person,
                        img_url_QID = imagesPath.University + UniversityDto.ImageName_QID,
                        img_url_Health = imagesPath.University + UniversityDto.ImageName_Health,
                        img_url_married = imagesPath.University + UniversityDto.ImageName_married,
                        img_url_other = imagesPath.University + UniversityDto.ImageName_other,
                        message = "",
                        success = true
                    });
                }
                else
                {
                    return Ok(new
                    {
                        datalist = UniversityDto,
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

        [HttpGet("GetProUniversitysAll")]
        public IActionResult GetProUniversitysAll(string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = UniversityService.GetProUniversitysAll();
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

