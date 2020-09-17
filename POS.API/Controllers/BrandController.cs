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
                var data = BrandService.GetProcBrands(CompanyId, @ImageURL);
                if (data != null)
                {
                    if (data.Count() == 0)
                    {
                        return Ok(new { success = true, message = Resources.lang.No_data_available, datalist = data.ToList() });
                    }
                    else
                    {
                        return Ok(new { success = true, message = "", datalist = data.ToList() });
                    }

                }
            }

            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message + " " + Resources.lang.An_error_occurred_while_processing_your_request });
            }

            return Ok(new { success = false, message = Resources.lang.No_data_available });
        }


        [HttpPost("SaveProcBrand")]
        public IActionResult SaveProcBrand(BrandsModel model)
        {
            try
            {
                var Brand = Mapper.Map<Brands>(model);
                BrandService.SaveProcBrands(Brand);
                var data = BrandService.SaveProcBrands(Brand);
                if (data != 1)
                {
                    if (data == -2)
                    {
                        return Ok(new { success = false, message = Resources.lang.English_name_already_exists, repeated = "en" });
                    }
                    if (data == -3)
                    {
                        return Ok(new { success = false, message = Resources.lang.Arabic_name_already_exists, repeated = "ar" });
                    }
                    if (data == -4)
                    {
                        return Ok(new { success = false, message = Resources.lang.English_group_name_for_mobile_already_exists, repeated = "en2" });
                    }
                    if (data == -5)
                    {
                        return Ok(new { success = false, message = Resources.lang.Arabic_group_name_for_mobile_already_exists, repeated = "ar2" });
                    }
                }
                else
                {
                    return Ok(new { success = true, message = Resources.lang.Saved_successfully_completed });
                }

            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message + " " + Resources.lang.An_error_occurred_while_processing_your_request });
            }
            return Ok(new { success = false + Resources.lang.An_error_occurred_while_processing_your_request });
        }
    }


}

