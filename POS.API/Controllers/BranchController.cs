using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Pos.IService;
using POS.Models;
using Pos.Service;
using POS.Entities;
using System.Linq;
using POS.Common;
using static POS.Common.Enums;
using System.Globalization;
using System.Threading;
using ImagesService;
using Exceptions;
namespace POS.API.CORE.Controllers
{
  //  [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BranchController : ControllerBase
    {
        private readonly ImagesPath _imagesPath;
        private IBranchService BranchService;

        private IMapper Mapper;
    
        public BranchController(
                                      IBranchService _BranchService,
                                      IMapper mapper
                                )
        {
            BranchService = _BranchService;
            Mapper = mapper;
   
        }


           
        [HttpGet("GetBranches")]
        public IActionResult GetBranches(int BrandID = 0, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = BranchService.GetProcBranches(BrandID, _imagesPath.branch);
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
                ExceptionError.SaveException(ex);
               
            }

            return BadRequest(new { success = false, message = Resources.lang.An_error_occurred_while_processing_your_request });

        }


        [HttpPost("Save_Branches")]
        public IActionResult Save_Branches(BranchesModel model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var Branch = Mapper.Map<Branches>(model);
             var data=   BranchService.SaveProcBranch(Branch);
                if (data != 1)
                {
                    if (data == -2)
                    {
                        return Ok(new { success = false, message = Resources.lang.English_name_already_exists, repeated = "BranchName" });
                    }
                    if (data == -3)
                    {
                        return Ok(new { success = false, message = Resources.lang.Arabic_name_already_exists, repeated = "BranchNameAr" });
                    }
                }
                else
                {
                    return Ok(new { success = true, message = Resources.lang.Saved_successfully_completed });
                }

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
                // return error message if there was an exception

            }
            return BadRequest(new { success = false, message = Resources.lang.An_error_occurred_while_processing_your_request });
        }
    }
}
