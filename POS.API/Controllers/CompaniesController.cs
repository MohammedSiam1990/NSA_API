using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Pos.IService;
using Pos.Service;
using POS.Models;
using System.Collections.Generic;
using POS.Entities;

namespace POS.API.CORE.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private ICompaniesService CompaniesService;
        private IMapper Mapper;
    
        public CompaniesController(
            ICompaniesService _CompaniesService,
            IMapper mapper)
        {
            CompaniesService = _CompaniesService;
            Mapper = mapper;
        
        }

       
        [HttpPost("AddCompany")]
        public IActionResult Add([FromBody]CompaniesModel model)
        {
            // map model to entity
            var Company = Mapper.Map<Companies>(model);
            try
            {
                if (CompaniesService.ValidateCompany(Company))
                // create Company
                {
                    CompaniesService.AddCompany(Company);
                return Ok(new { message = "Add Company Success" });
                }

                return Ok(new { message = "Data is Not Complete" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("UpdateCompany")]
        public IActionResult Update([FromBody]CompaniesModel model)
        {
            // map model to entity
            var Company = Mapper.Map<Companies>(model);
            try
            {
                if (CompaniesService.ValidateCompany(Company))
                // Edit Company
                {

                    CompaniesService.UpdateCompany(Company);
                    return Ok(new { message = "Update Company Success" });
                }
                return Ok(new { message = "Data is Not Complete" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("DeleteCompany")]
        public IActionResult Delete(int CompanyId)
        {

            try
            {
                    CompaniesService.DeleteCompany(CompanyId);
                    return Ok(new { message = "Delete Company Success" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
     
        
        [HttpGet("GetCompany")]
        public IActionResult GetCompany(int CompanyId)
        {
       try
            {
                // create user
              var Company=  CompaniesService.GetCompany(CompanyId);
                var CompanyDto = Mapper.Map<CompaniesModel>(Company);
                return Ok(new { CompanyDto, message = "Success" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("GetCompanies")]
        public IActionResult GetCompanies()
        {
       try
            {
                // create user
               var  companies = CompaniesService.GetCompanies();
                var companiesDto = Mapper.Map<List<CompaniesModel>>(companies);
                return Ok(new { companiesDto, message = "Success" });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
