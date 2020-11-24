using AutoMapper;
using Exceptions;
using ImagesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pos.IService;
using POS.API.Models;
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
    public class CityController : ControllerBase
    {

        private ImagesPath imagesPath;

        private ICityService CityService;
        private ICountryService CountryService;
        private IMapper Mapper;

        public CityController(
            ICountryService _CountryService,
            ICityService _CityService,
            ImagesPath _imagesPath,
            IMapper mapper)
        {
            CountryService = _CountryService;
            CityService = _CityService;
            Mapper = mapper;
            imagesPath = _imagesPath;
        }


        [HttpPost("AddCity")]
        public IActionResult Add([FromBody]CityModel model, string Lang = "en")
        {
            // map model to entity
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
            try
            {
                var City = Mapper.Map<City>(model);


                var ExistModel = CityService.ValidateAlreadyExist(City);
                if (ExistModel != null)
                {
                    string CityAlert;
                    if (City.CityName == ExistModel.CityName)
                    {
                        CityAlert = " , CityName : " + ExistModel.CityName;
                        return Ok(new { success = false, message = lang.English_name_already_exists + CityAlert });
                    }
                    else
                    {
                        CityAlert = " , CityNameAr : " + ExistModel.CityNameAr;
                        return Ok(new { success = false, message = lang.Arabic_name_already_exists + CityAlert });
                    }
                }

                CityService.AddCity(City);
                    return Ok(new { message =lang.Saved_successfully_completed});
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }

        [HttpPost("UpdateCity")]
        public IActionResult Update([FromBody]CityModel model, string Lang = "en")
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
            try
            {

                var City = Mapper.Map<City>(model);
                var ExistModel = CityService.ValidateAlreadyExist(City);
                if (ExistModel != null)
                {
                    string CityAlert;
                    if (City.CityName == ExistModel.CityName)
                    {
                        CityAlert = " , CityName : " + ExistModel.CityName;
                        return Ok(new { success = false, message = lang.English_name_already_exists + CityAlert });
                    }
                    else
                    {
                        CityAlert = " , CityNameAr : " + ExistModel.CityNameAr;
                        return Ok(new { success = false, message = lang.Arabic_name_already_exists + CityAlert });
                    }
                }
             
                    CityService.UpdateCity(City);
                    return Ok(new { success = true, message = lang.Updated_successfully_completed });
               
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }

        [HttpPost("DeleteCity")]
        public IActionResult Delete(int CityId)
        {

            try
            {
                CityService.DeleteCity(CityId);
                return Ok(new { message = lang.Deleted_successfully });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return Ok(new { message = ex.Message });
            }
        }
        [HttpPost("SaveCity")]
        public IActionResult SaveCity(CityModel model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
                
                var City = Mapper.Map<City>(model);
                  var ExistModel = CityService.ValidateAlreadyExist(City);
                    if (ExistModel != null)
                    {
                      string CityAlert ;
                        if (City.CityName == ExistModel.CityName)
                        {
                            CityAlert = " , CityName : " + ExistModel.CityName;
                            return Ok(new { success = false, message = lang.English_name_already_exists + CityAlert });
                        }
                        else
                        {
                            CityAlert = " , CityNameAr : " + ExistModel.CityNameAr;
                            return Ok(new { success = false, message = lang.Arabic_name_already_exists + CityAlert });
                        }
                    }
                int result = CityService.SaveCity(City);
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

        [HttpGet("GetCityById")]
        public IActionResult GetCityById(int CityId, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
                var City = CityService.GetCity(CityId);
                var CityDto = Mapper.Map<CityModel>(City);

                return Ok(new { datalist = CityDto, message = "", success = true });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

        [HttpGet("GetCities/CountryId")]
        public IActionResult GetCities( int CountryId,string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var Cities = CityService.GetCities(CountryId);
                var CitiesDto = Mapper.Map<List<CityModel>>(Cities);
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
                // return error message if there was an exception
                ExceptionError.SaveException(ex);

            }

            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }
        [HttpGet("GetCountries/CountryId")]
        public IActionResult GetCountries( string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var Country = CountryService.GetCountries();
                var CountryDto = Mapper.Map<List<CityModel>>(Country);
                if (CountryDto != null)
                {
                    if (CountryDto.Count() == 0)
                    {
                        return Ok(new { success = true, message = lang.No_data_available, datalist = CountryDto });
                    }
                    else
                    {
                        return Ok(new { success = true, message = "", datalist = CountryDto });
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

