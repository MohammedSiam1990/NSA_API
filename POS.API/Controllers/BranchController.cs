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

namespace POS.API.CORE.Controllers
{
  //  [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BranchController : ControllerBase
    {
    
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


           
        [HttpGet("GetProcBranches")]
        public IActionResult GetProcBranches(int BrandId, string @ImageURL)
        {
            try
            {

                var data = BranchService.GetProcBranches(BrandId, @ImageURL);
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


        [HttpPost("SaveProcBranch")]
        public IActionResult SaveProcBranch(BranchesModel model)
        {


            try
            {

                var Branch = Mapper.Map<Branches>(model);
             var data=   BranchService.SaveProcBranch(Branch);
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
