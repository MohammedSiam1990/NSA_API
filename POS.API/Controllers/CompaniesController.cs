using AutoMapper;
using Exceptions;
using ImagesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pos.IService;
using POS.Core.Resources;
using POS.Entities;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

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
        public IActionResult Add([FromBody]CompaniesModel model, string Lang = "en")
        {
            // map model to entity
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

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

        [HttpPost("DeletCompanyeAndUser")]
        public IActionResult DeletCompanyeAndUser(int CompanyId, string Lang = "en")
        {
            // map model to entity
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);


            try
            {

                var data = CompaniesService.DeletCompanyeAndUser(CompanyId);
                if (data != 1)
                {
                    return Ok(new { success = false, message = lang.Deleted_Faild });
                }
                else
                {
                    return Ok(new { success = true, message = lang.Deleted_successfully });
                }

            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

        [HttpPost("UpdateCompany")]
        public IActionResult Update([FromBody]CompaniesModel model, string Lang = "en")
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

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
                var Company = CompaniesService.GetCompany(CompanyId);
                var CompanyDto = Mapper.Map<CompaniesModel>(Company);
                CompanyDto.ImageName = imagesPath.Comapny + CompanyDto.ImageName;

                return Ok(new { datalist = CompanyDto, message = "", success = true });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

        [HttpGet("GetCompanies")]
        public IActionResult GetCompanies(string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = CompaniesService.GetCompanies();
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
                // return error message if there was an exception
                ExceptionError.SaveException(ex);

            }

            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

    }
}

