using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS.API.Models;
using POS.Core.Resources;
using POS.Data.Entities;
using POS.Service.IService;

namespace POS.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private ICustomerService customerService;
        private IAddressService AddressService;
        private IMapper Mapper;

        public CustomerController(IMapper mapper, ICustomerService _customerService, IAddressService _AddressService)
        {
            customerService = _customerService;
            AddressService = _AddressService;
            Mapper = mapper;
        }
        [HttpPost("SaveCustomer")]
        public IActionResult SaveCustomer(CustomerModel model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var Customer = Mapper.Map<Customer>(model);
                int CustomerData = customerService.ValidateCustomerAlreadyExist(Customer);
                if (CustomerData == 1)
                {
                    if (Customer.CustomerID == 0)
                        customerService.AddCustomer(Customer);
                    else
                    {
                        customerService.UpdateCustomer(Customer);
                    }
                    return Ok(new { success = true, message = lang.Saved_successfully_completed });

                }
                else
                {
                    if (CustomerData == -2)
                        return Ok(new { success = false, message = lang.Number_already_exists, repeated = "CustomerNum" });
                    if (CustomerData == -3)
                        return Ok(new { success = false, message = lang.Phone_already_exists, repeated = "Mobile" });

                }

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
                // return error message if there was an exception

            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }
        [HttpGet("GetCustomer")]
        public IActionResult GetCustomer(int CompanyID = 0, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = customerService.GetCustomer(CompanyID);
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

        [HttpGet("GetAddress")]
        public IActionResult GetAddress(int CustomerID = 0, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = customerService.GetAddress(CustomerID);
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

        [HttpPost("SaveAddress")]
        public IActionResult SaveAddress(AddressModel model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var adress = Mapper.Map<Address>(model);
                if (model.AddressID == 0)
                    AddressService.AddAddress(adress);
                else
                {
                    AddressService.UpdateAddress(adress);
                }
                return Ok(new { success = true, message = lang.Saved_successfully_completed });

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
                // return error message if there was an exception

            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }

    }
}