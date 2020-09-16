using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Pos.IService;
using POS.Entities;
using Pos.Service;
using POS.Models;
using System.Linq;

namespace POS.API.CORE.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
    
        private ICityService CityService;
        private IMapper Mapper;
    
        public CityController(
            ICityService _CityService,
            IMapper mapper)
        {
            CityService = _CityService;
            Mapper = mapper; 
        }

        [HttpPost("AddCity")]
        public IActionResult AddCity([FromBody]CitiesModel model)
        {
            // map model to entity
            var City = Mapper.Map<City>(model);
            try
            {
                if (CityService.ValidateCity(City))
                // create City
                {
                    CityService.AddCity(City);

                    return Ok(new { message = "Add City Success" });
                }

                return Ok(new { message = "Data is Not Complete" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPost("UpdateCity")]
        public IActionResult UpdateCity([FromBody]CitiesModel model)
        {
            // map model to entity
            var City = Mapper.Map<City>(model);
            try
            {
                if (CityService.ValidateCity(City))
                // Edit City
                {

                    CityService.UpdateCity(City);
                    return Ok(new { message = "Update City Success" });
                }
                return Ok(new { message = "Data is Not Complete" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("DeleteCity")]
        public IActionResult DeleteCity(int CityId)
        {
            // map model to entity
            try
            {
                CityService.DeleteCity(CityId);
                return Ok(new { message = "Delete City Success" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet("GetCityById")]
        public IActionResult GetCityById(int CityId)
        {
            try
            {
                // create user
                var City = CityService.GetCityById(CityId);
                var CityDto = Mapper.Map<CitiesModel>(City);
                return Ok(new { CityDto, message = "Success" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("GetCityByCountry")]
        public IActionResult GetCity(int CountryId)
        {
            try
            {
                // create user
                var City = CityService.GetCity(CountryId);
                var CityDto = Mapper.Map<List<CitiesModel>>(City);
                return Ok(new { CityDto, message = "Success" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("GetCity")]
               public IActionResult GetCity()
        {
            try
            {
                // create user
                var City = CityService.GetCity();
                 var CityDto = Mapper.Map<List<CitiesModel>>(City);
                return Ok(new { CityDto, message = "Success" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }


      














    }
}
