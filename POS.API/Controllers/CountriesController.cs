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
    public class CountriesController : ControllerBase
    {
    
        private ICountryService CountriesService;
        private IMapper Mapper;
    
        public CountriesController(
            ICountryService _CountriesService,
            IMapper mapper)
        {
            CountriesService = _CountriesService;
            Mapper = mapper; 
        }

        [HttpPost("AddCountries")]
        public IActionResult AddCountries([FromBody]CountriesModel model)
        {
            // map model to entity
            var Countries = Mapper.Map<Country>(model);
            try
            {
                if (CountriesService.ValidateCountry(Countries))
                // create Countries
                {
                    CountriesService.AddCountry(Countries);

                    return Ok(new { message = "Add Countries Success" });
                }

                return Ok(new { message = "Data is Not Complete" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPost("UpdateCountries")]
        public IActionResult UpdateCountries([FromBody]CountriesModel model)
        {
            // map model to entity
            var Countries = Mapper.Map<Country>(model);
            try
            {
                if (CountriesService.ValidateCountry(Countries))
                // Edit Countries
                {

                    CountriesService.UpdateCountry(Countries);
                    return Ok(new { message = "Update Countries Success" });
                }
                return Ok(new { message = "Data is Not Complete" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("DeleteCountries")]
        public IActionResult DeleteCountries(int CountriesId)
        {
            // map model to entity
            try
            {
                CountriesService.DeleteCountry(CountriesId);
                return Ok(new { message = "Delete Countries Success" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }



    
 




        [HttpGet("GetCountriesById")]
        public IActionResult GetCountriesById(int CountriesId)
        {
            try
            {
                // create user
                var Countries = CountriesService.GetCountryById(CountriesId);
                var CountriesDto = Mapper.Map<CountriesModel>(Countries);
                return Ok(new { CountriesDto, message = "Success" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("GetCountries")]
        [AllowAnonymous]
        public IActionResult GetCountries()
        {
            try
            {
                // create user
                var Countries = CountriesService.GetCountry();
                 var CountriesDto = Mapper.Map<List<CountriesModel>>(Countries);
                return Ok(new { CountriesDto, message = "Success" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }


      














    }
}
