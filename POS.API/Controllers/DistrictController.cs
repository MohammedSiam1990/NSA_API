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
  public class DistrictController : ControllerBase
  {

    private IDistrictService DistrictService;
    private IMapper Mapper;

    public DistrictController(
     IDistrictService _DistrictService,
     IMapper mapper)
    {
      DistrictService = _DistrictService;
      Mapper = mapper;
    }

    [HttpPost("AddDistract")]
    public IActionResult Add([FromBody]DistrictModel model, string Lang = "en")
    {
      // map model to entity
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
      Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
      try
      {
        var District = Mapper.Map<District>(model);
     
        var ExistModel = DistrictService.ValidateAlreadyExist(District);
        if (ExistModel != null)
          {
            string ServiceTypesAlert;
            if (District.DistrictName == ExistModel.DistrictName)
            {
              ServiceTypesAlert = " , DistrictName : " + ExistModel.DistrictName;
              return Ok(new { success = false, message = lang.English_name_already_exists + ServiceTypesAlert });
            }
            else
            {
              ServiceTypesAlert = " , DistrictNameAr : " + ExistModel.DistrictNameAr;
              return Ok(new { success = false, message = lang.Arabic_name_already_exists + ServiceTypesAlert });
            }
          }
        
        DistrictService.AddDistrict(District);
        return Ok(new { success = true, message = lang.Saved_successfully_completed });
      }
      catch (Exception ex)
      {
        // return error message if there was an exception
        ExceptionError.SaveException(ex);
      }
      return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
    }

    [HttpPost("UpdateDistrict")]
    public IActionResult Update([FromBody]DistrictModel model, string Lang = "en")
    {
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
      Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

      try
      {
        var District = Mapper.Map<District>(model);

        var ExistModel = DistrictService.ValidateAlreadyExist(District);
        if (ExistModel != null)
        {
          string ServiceTypesAlert;
          if (District.DistrictName == ExistModel.DistrictName)
          {
            ServiceTypesAlert = " , DistrictName : " + ExistModel.DistrictName;
            return Ok(new { success = false, message = lang.English_name_already_exists + ServiceTypesAlert });
          }
          else
          {
            ServiceTypesAlert = " , DistrictNameAr : " + ExistModel.DistrictNameAr;
            return Ok(new { success = false, message = lang.Arabic_name_already_exists + ServiceTypesAlert });
          }
        }

        DistrictService.UpdateDistrict(District);
        return Ok(new { success = true, message = lang.Saved_successfully_completed });
      }
      //  return Ok(new { success = false, message = lang.Update_operation_failed });
    
      catch (Exception ex)
      {
        // return error message if there was an exception
        ExceptionError.SaveException(ex);
      }
      return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

    }

    [HttpGet("GetDistricts")]
    public IActionResult GetDistricts(string Lang = "en")
    {
      try
      {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

        var Districts = DistrictService.GetDistricts();
        var data = Mapper.Map<List<DistrictModel>>(Districts);
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

    [HttpGet("GetDistrict")]
    public IActionResult GetDistrict(int DistrictId, string Lang = "en")
    {

      try
      {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

        var District = DistrictService.GetDistrict(DistrictId);
        var data = Mapper.Map<List<DistrictModel>>(District);

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

  }
}
