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
    public class ApproveRejectSoldierController : ControllerBase
    {

        private ImagesPath imagesPath;
        private ISoldierService SoldierService;
        private IMapper Mapper;

        public ApproveRejectSoldierController(
            ISoldierService _SoldierService,
            ImagesPath _imagesPath,
            IMapper mapper)
        {
           
            SoldierService = _SoldierService;
            Mapper = mapper;
            imagesPath = _imagesPath;
        }


     
         

        [HttpPost("DeleteSoldier")]
        public IActionResult Delete(int SoldierId)
        {

            try
            {
                SoldierService.DeleteSoldier(SoldierId);
                return Ok(new { message = lang.Deleted_successfully });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }
        [HttpPost("SaveSoldier")]
        public IActionResult SaveSoldier(SoldierModel model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var Soldier = Mapper.Map<Soldier>(model);
                var ExistModel = SoldierService.ValidateAlreadyExist(Soldier);
                if (ExistModel != null)
                {
                    string SoldierAlert;
                    if (Soldier.SoldierName1 == ExistModel.SoldierName1)
                    {
                        SoldierAlert = " , SoldierName1 : " + ExistModel.SoldierName1;
                        return Ok(new { success = false, message = lang.English_name_already_exists + SoldierAlert });
                    }
                    else if (Soldier.SoldierName2 == ExistModel.SoldierName2)
                    {
                        SoldierAlert = " , SoldierName2 : " + ExistModel.SoldierName2;
                        return Ok(new { success = false, message = lang.English_name_already_exists + SoldierAlert });
                    }
                    else if (Soldier.SoldierName3 == ExistModel.SoldierName3)
                    {
                        SoldierAlert = " , SoldierName3 : " + ExistModel.SoldierName3;
                        return Ok(new { success = false, message = lang.English_name_already_exists + SoldierAlert });
                    }
                    else if (Soldier.SoldierName4 == ExistModel.SoldierName4)
                    {
                        SoldierAlert = " , SoldierName4 : " + ExistModel.SoldierName4;
                        return Ok(new { success = false, message = lang.English_name_already_exists + SoldierAlert });
                    }
                    else
                    {
                        SoldierAlert = " , SoldierNameEN : " + ExistModel.SoldierNameEN;
                        return Ok(new { success = false, message = lang.Arabic_name_already_exists + SoldierAlert });
                    }
                }
                int result = SoldierService.SaveSoldier(Soldier, imagesPath.NSR + "nsf2-logo.svg");
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

        [HttpGet("GetSoldierById")]
        public IActionResult GetSoldierById(int InsertedBy, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
                var Soldier = SoldierService.GetSoldier(InsertedBy);
                var SoldierDto = Mapper.Map<SoldierModel>(Soldier);





                if (SoldierDto != null )
                {
                    return Ok(new
                    {
                        datalist = SoldierDto,  
                        img_url_Passport = imagesPath.Soldier + SoldierDto.ImageName_Passport,
                        img_url_Clearance = imagesPath.Soldier + SoldierDto.ImageName_Clearance,
                        img_url_Certificates = imagesPath.Soldier + SoldierDto.ImageName_Certificates,
                        img_url_person = imagesPath.Soldier + SoldierDto.ImageName_person,
                        img_url_militarycard = imagesPath.Soldier + SoldierDto.ImageName_militarycard,
                        img_url_other = imagesPath.Soldier + SoldierDto.ImageName_other,

                        message = "",
                        success = true
                    });
                }
                else
                {
                    return Ok(new
                    {
                        datalist = SoldierDto,
                        img_url_Passport = "",
                        img_url_Clearance = "",
                        img_url_Certificates = "",
                        img_url_person = "",
                        img_url_militarycard = "",
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

        [HttpGet("GetProSoldiersAll")]
        public IActionResult GetProSoldiersAll(string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = SoldierService.GetProSoldiersAll();
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

