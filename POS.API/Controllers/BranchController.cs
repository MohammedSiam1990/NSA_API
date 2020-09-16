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

                var Branches = BranchService.GetProcBranches(BrandId, @ImageURL);

                return Ok(new { Branches, message = "Success" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPost("SaveProcBranch")]
        public IActionResult SaveProcBranch(BranchesModel model)
        {
            try
            {

                var Branch = Mapper.Map<Branches>(model);
                BranchService.SaveProcBranch(Branch);
                return Ok(new { message = "Add Branch Success" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
