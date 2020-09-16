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
using POS.Common;
using POS.API.Helpers;
using POS.DTO;
using POS.API.Models;

namespace POS.API.CORE.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
    
        private IBrandService BrandService;

   
        private IMapper Mapper;
    
        public BrandController(  IBrandService _BrandService
                                , IMapper mapper)
        {
            BrandService = _BrandService;

            Mapper = mapper; 
        }


        [HttpGet("GetProcBrandes")]
        public IActionResult GetProcBrandes(int CompanyId, string @ImageURL)
        {
            try
            {
                var Brandes = BrandService.GetProcBrands(CompanyId, @ImageURL);
                return Ok(new { Brandes, message = "Success" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPost("SaveProcBrand")]
        public IActionResult SaveProcBrand(BrandsModel model)
        {
            try
            {
                var Brand = Mapper.Map<Brands>(model);
                BrandService.SaveProcBrands(Brand);
                return Ok(new { message = "Add Brand Success" });
            } 
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}
