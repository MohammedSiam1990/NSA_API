using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Pos.IService;
using Pos.Service;
using POS.Models;
using System.Collections.Generic;
using POS.Entities;
using ImagesService;
using POS.Core.Resources;
using Exceptions;

namespace POS.API.CORE.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {

        private ImagesPath imagesPath;

        private ICompaniesService CompaniesService;
        private IMapper Mapper;
    
        public CompaniesController(
            ICompaniesService _CompaniesService,
            ImagesPath _imagesPath,
            IMapper mapper)
        {
            CompaniesService = _CompaniesService;
            Mapper = mapper;
            imagesPath = _imagesPath;
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
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

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
                    return Ok(new { success = true, message = lang.Updated_successfully_completed });
                }


                return Ok(new { success = false, message = lang.Update_operation_failed });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

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
                return Ok(new { message = ex.Message });
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
                CompanyDto.ImageName = imagesPath.Comapny + CompanyDto.ImageName;

                return Ok(new { datalist = CompanyDto, message = "" , success = true });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

        [HttpGet("GetCompanies")]
        public IActionResult GetCompanies()
        {
       try
            {
                // create user
               var  companies = CompaniesService.GetCompanies();
                var companiesDto = Mapper.Map<List<CompaniesModel>>(companies);
                return Ok(new { datalist = companiesDto, message = "", success = true });
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
