using AutoMapper;
using Exceptions;
using ImagesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSR.IService;
using NSR.Common;
using NSR.Core.Resources;
using NSR.Entities;
using NSR.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace NSR.API.CORE.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {

        private ImagesPath imagesPath;
        private IBrandService BrandService;


        private IMapper Mapper;

        public BrandController(IBrandService _BrandService,
                         ImagesPath _imagesPath,
                                 IMapper mapper)
        {
            BrandService = _BrandService;
            imagesPath = _imagesPath;
            Mapper = mapper;
        }


        [HttpGet("GetBrands")]
        public IActionResult GetBrands(long UserID,int CompanyId = 0 ,string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = BrandService.GetProcBrands(CompanyId, UserID, imagesPath.Brand);
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

        [HttpPost("Save_Brand")]
        public IActionResult Save_Brand(BrandsModel model, string Lang = "en")
        {
            try
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
                string ParamName;
                bool valid = CommandTextValidator.ValidateStatement(out ParamName, model.BrandName, model.BrandNameAr);
                if (valid == false)
                {
                    return Ok(new { success = false, Name = ParamName, message = lang.Please_Remove_special_characters });
                }

                var Brand = Mapper.Map<Brands>(model);
                var data = BrandService.SaveProcBrands(Brand);
                if (data != 1)
                {
                    if (data == -1)
                    {
                        return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

                    }
                    if (data == -2)
                    {
                        return Ok(new { success = false, message = lang.English_name_already_exists, repeated = "BrandName" });
                    }
                    if (data == -3)
                    {
                        return Ok(new { success = false, message = lang.Arabic_name_already_exists, repeated = "BrandNameAr" });
                    }
                }
                else
                {
                    return Ok(new { success = true, message = lang.Saved_successfully_completed });
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

