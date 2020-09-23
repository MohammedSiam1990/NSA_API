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
using POS.API.Models;
using System.Threading;
using System.Globalization;
using ImagesService;
using Exceptions;
using POS.Core.Resources;

namespace POS.API.CORE.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {

        private ImagesPath imagesPath;
        private IBrandService BrandService;

   
        private IMapper Mapper;
    
        public BrandController(  IBrandService _BrandService,
                         ImagesPath _imagesPath,
                                 IMapper mapper)
        {
            BrandService = _BrandService;
            imagesPath = _imagesPath;
            Mapper = mapper; 
        }


        [HttpGet("GetBrands")]
        public IActionResult GetBrands(int CompanyId = 0, string Lang = "en")
        {
            try
            {
                
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = BrandService.GetProcBrands(CompanyId, imagesPath.brand);
                if (data != null)
                {
                    if (data.Count() == 0)
                    {
                        return Ok(new { success = true, message =lang.No_data_available, datalist = data.ToList() });
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
                ExceptionError.SaveException(ex);

            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

        [HttpPost("Save_Brand")]
        public IActionResult Save_Brand(BrandsModel model, string Lang = "en")
        {
            try
            {
               
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var Brand = Mapper.Map<Brands>(model);
                BrandService.SaveProcBrands(Brand);
                var data = BrandService.SaveProcBrands(Brand);
                if (data != 1)
                {
                    if (data == -1)
                    {
                        return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request});

                    }
                    if (data == -2)
                    {
                        return Ok(new { success = false, message =lang.English_name_already_exists, repeated = "BrandName" });
                    }
                    if (data == -3)
                    {
                        return Ok(new { success = false, message =lang.Arabic_name_already_exists, repeated = "BrandNameAr" });
                    }
                }
                else
                {
                    return Ok(new { success = true, message =lang.Saved_successfully_completed });
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

