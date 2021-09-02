using AutoMapper;
using Exceptions;
using ImagesService;
using Microsoft.AspNetCore.Mvc;
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
    public class UniversityController : ControllerBase
    {

        private ImagesPath imagesPath;
        private IUniversityService UniversityService;
        private IMapper Mapper;

        public UniversityController(
            IUniversityService _UniversityService,
            ImagesPath _imagesPath,
            IMapper mapper)
        {
           
            UniversityService = _UniversityService;
            Mapper = mapper;
            imagesPath = _imagesPath;
        }


        [HttpPost("AddUniversity")]
        public IActionResult Add([FromBody]UniversityModel model, string Lang = "en")
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
            try
            {
                string ParamName;
                bool valid = CommandTextValidator.ValidateStatement(out ParamName, model.UniversityName1, model.UniversityName2, model.UniversityName3, model.UniversityName4, model.UniversityNameEN);
                if (valid == false)
                {
                    return Ok(new { success = false, Name = ParamName, message = lang.Please_Remove_special_characters });
                }

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
                    else if (University.UniversityQID == ExistModel.UniversityQID)
                    {
                        UniversityAlert = " , QID : " + ExistModel.UniversityQID;
                        return Ok(new { success = false, message = lang.QID_already_exists + UniversityAlert });
                    }
                    else
                    {
                        UniversityAlert = " , UniversityNameEN : " + ExistModel.UniversityNameEN;
                        return Ok(new { success = false, message = lang.Arabic_name_already_exists + UniversityAlert });
                    }
                }

                UniversityService.AddUniversity(University);
                return Ok(new { success = true, message = lang.Saved_successfully_completed });
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }

        [HttpPost("UpdateUniversity")]
        public IActionResult Update([FromBody]UniversityModel model, string Lang = "en")
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
            try
            {

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

                    else if (University.UniversityQID == ExistModel.UniversityQID)
                    {
                        UniversityAlert = " , QID : " + ExistModel.UniversityQID;
                        return Ok(new { success = false, message = lang.QID_already_exists + UniversityAlert });
                    }
                    else
                    {
                        UniversityAlert = " , UniversityNameEN : " + ExistModel.UniversityNameEN;
                        return Ok(new { success = false, message = lang.Arabic_name_already_exists + UniversityAlert });
                    }
                }

                UniversityService.UpdateUniversity(University);
                return Ok(new { success = true, message = lang.Updated_successfully_completed });

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
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
                    else if (University.UniversityQID == ExistModel.UniversityQID)
                    {
                        UniversityAlert = " , QID : " + ExistModel.UniversityQID;
                        return Ok(new { success = false, message = lang.QID_already_exists + UniversityAlert });
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
        public IActionResult GetUniversityById(int InsertedBy, int companyId = 0, string Lang = "en")
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
                        img_url_Transcript = imagesPath.University + UniversityDto.ImageName_Transcript,
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
                        img_url_Transcript = "",
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




        [HttpGet("GetUniversityByuniversityID")]
        public IActionResult GetUniversityByuniversityID(int UniversityID,   string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
                var University = UniversityService.GetUniversityID(UniversityID);
                var UniversityDto = Mapper.Map<UniversityModel>(University);





                if (UniversityDto != null)
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
                        img_url_Transcript = imagesPath.University + UniversityDto.ImageName_Transcript,
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
                        img_url_Transcript = "",
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

        [HttpGet("GetUniversitysAll")]
        public IActionResult GetUniversitysAll(string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var Cities = UniversityService.GetUniversitys();
                var CitiesDto = Mapper.Map<List<UniversityModel>>(Cities);
                if (CitiesDto != null)
                {
                    if (CitiesDto.Count() == 0)
                    {
                        return Ok(new { success = true, message = lang.No_data_available, datalist = CitiesDto });
                    }
                    else
                    {
                        return Ok(new { success = true, message = "", datalist = CitiesDto });
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

