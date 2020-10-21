using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using EmailService;
using Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pos.IService;
using POS.API.Helpers;
using POS.API.Models;
using POS.Core.Resources;
using POS.Data.Entities;
using POS.Service.IService;
using POS.Service.Services;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchWorkStationsController : ControllerBase
    {
        private IBranchWorkStationsService BranchWorkStationsService;
        private IAccountService _accountService;
        private IMailService _mailService;
        private IMapper Mapper;
        EmailConfiguration emailConfig;

        public BranchWorkStationsController(IAccountService accountService
    , IBranchWorkStationsService _BranchWorkStationsService, IMapper mapper, IMailService mailService, EmailConfiguration _emailConfig)
        {
            BranchWorkStationsService = _BranchWorkStationsService;
            Mapper = mapper;
            _accountService = accountService;
            _mailService = mailService;
            emailConfig = _emailConfig;

        }

        [HttpPost("SaveBranchWorkStations")]
        public IActionResult SaveBranchWorkStationsService(BranchWorkStationsModel model, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
                var branchWorkStations = Mapper.Map<BranchWorkStations>(model);
                int data = BranchWorkStationsService.ValidateNameAlreadyExist(branchWorkStations);
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = _accountService.GetUserAsync(userId);
                var UserType = (user.Result.UserType);
                var  CreateUser = _accountService.GetUserAsync(model.CreatedBy); 

                if (data == 1)
                {
                    if (branchWorkStations.BranchWorkstationID == 0)
                        BranchWorkStationsService.AddBranchWorkStations(branchWorkStations);
                    else
                    {

                        try
                        {
                            if (branchWorkStations.StatusID == 7 && UserType == 2)
                            {
                                branchWorkStations.ApprovedDate = DateTime.Now;
                                string serial= branchWorkStations.Serial = Guid.NewGuid().ToString("D");
                                BranchWorkStationsService.UpdateBranchWorkStations(branchWorkStations);
                                string Subject = "workstation serial ";
                                string Body =  lang.Dear_Client_your_workstation  + branchWorkStations.WorkstationName + lang.Serila_is + serial ;


                                bool isMessageSent = _mailService.SendEmailAsync(emailConfig.SmtpServer, emailConfig.Port, emailConfig.EnableSsl, emailConfig.From, CreateUser.Result.Email, Subject, Body, emailConfig.From, emailConfig.Password, emailConfig.UseDefaultCredentials);


                            }
                            else if ((branchWorkStations.StatusID == 7 || branchWorkStations.StatusID == 6) && (UserType == 1 || UserType == 2))
                            {
                                branchWorkStations.LastModifyDate = DateTime.Now;
                                BranchWorkStationsService.UpdateBranchWorkStations(branchWorkStations);

                            }

                        }
                        catch (Exception ex)
                        {
                            throw new AppException(ex.Message);
                        }
                    }
                    return Ok(new { success = true, message = lang.Saved_successfully_completed });
                }
                else if (data == -1)
                    return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
                else if (data == -2)
                    return Ok(new { success = false, message = lang.Name_already_exists, repeated = "branchWorkStationsName" });
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
                // return error message if there was an exception

            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }
        [HttpGet("GetWorkStations")]
        public IActionResult GetWorkStations( string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = BranchWorkStationsService.GetWorkStations();
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
