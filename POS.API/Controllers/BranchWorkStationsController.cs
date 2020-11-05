using AutoMapper;
using EmailService;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pos.IService;
using POS.API.Helpers;
using POS.API.Models;
using POS.Core.Resources;
using POS.Data.Entities;
using POS.Service.IService;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading;

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
                var CreateUser = _accountService.GetUserAsync(model.CreatedBy);

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
                                string serial = branchWorkStations.Serial = Guid.NewGuid().ToString("D");
                                BranchWorkStationsService.UpdateBranchWorkStations(branchWorkStations);
                                string Subject = "workstation serial ";
                                //string Body = lang.Dear_Client_your_workstation + branchWorkStations.WorkstationName + lang.Serila_is + serial;
                                string Body = "<html xmlns='http://www.w3.org/1999/xhtml'><head><meta http-equiv='content-type' content='text/html; charset=utf-8'>    <meta name='viewport' content='width=device-width, initial-scale=1.0;'>    <meta name='format-detection' content='telephone=no' />    <style>        body {            margin: 0;            padding: 0;            min-width: 100%;            width: 100% !important;            height: 100% !important;        }                body,        table,        td,        div,        p,        a {            -webkit-font-smoothing: antialiased;            text-size-adjust: 100%;            -ms-text-size-adjust: 100%;            -webkit-text-size-adjust: 100%;            line-height: 100%;        }                table,        td {            mso-table-lspace: 0pt;            mso-table-rspace: 0pt;            border-collapse: collapse !important;            border-spacing: 0;        }                img {            border: 0;            line-height: 100%;            outline: none;            text-decoration: none;            -ms-interpolation-mode: bicubic;        }                #outlook a {            padding: 0;        }                .ReadMsgBody {            width: 100%;        }                .ExternalClass {            width: 100%;        }                .ExternalClass,        .ExternalClass p,        .ExternalClass span,        .ExternalClass font,        .ExternalClass td,        .ExternalClass div {            line-height: 100%;        }                @media all and (min-width: 560px) {            .container {                border-radius: 8px;                -webkit-border-radius: 8px;                -moz-border-radius: 8px;                -khtml-border-radius: 8px;            }        }                a,        a:hover {            color: #0a5c80;        }                .footer a,        .footer a:hover {            color: #828999;        }    </style>    <title></title></head><body topmargin='0' rightmargin='0' bottommargin='0' leftmargin='0' marginwidth='0' marginheight='0' width='100%' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; width: 100%; height: 100%; -webkit-font-smoothing: antialiased; text-size-adjust: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; line-height: 100%;	background-color: #ffff;	color: #0a5c80;' bgcolor='#fff' text='##0a5c80'>    <table width='100%' align='center' border='0' cellpadding='0' cellspacing='0' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; width: 100%;' class='background'>        <tr>            <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0;' bgcolor='#fff'>                <table border='0' cellpadding='0' cellspacing='0' align='center' width='500' style='border-collapse: collapse; border-spacing: 0; padding: 0; width: inherit;	max-width: 500px;' class='wrapper'>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%;			padding-top: 20px;			padding-bottom: 20px;'>                            <div style='display: none; visibility: hidden; overflow: hidden; opacity: 0; font-size: 1px; line-height: 1px; height: 0; max-height: 0; max-width: 0;				color: #2D3445;' class='preheader'>                            </div>                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0;			padding-top: 0px;' class='hero'>                            <a target='_blank' style='text-decoration: none;' href='#'><img border='0' vspace='0' hspace='0' src='http://pos.opos.me/assets/images/arqami_logo.svg' alt='Please enable images to view this content' title='Hero Image' width='340' style='			width: 87.5%;			max-width: 340px;			color: #0a5c80; font-size: 13px; margin: 0; padding: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: block;' /></a>                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 14px; font-weight: 400; line-height: 150%; letter-spacing: 2px;			padding-top: 27px;			padding-bottom: 0;			color: #0a5c80;			font-family: sans-serif;' class='supheader'>                            Welcome To                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0;  padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 24px; font-weight: bold; line-height: 130%;			padding-top: 5px;			color: #0a5c80;			font-family: sans-serif;' class='header'>                            POS Arqami System                        </td>                    </tr>                    <tr>                        <td align='right' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 17px; font-weight: 400; line-height: 160%;			padding-top: 15px; 			color: #0a5c80;            font-family: sans-serif; text-align: center;' class='paragraph'>Dear Client,your workstation Pos branch serial is:                            <b class='text-center'> .</b>                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%;			padding-top: 25px;			padding-bottom: 5px;' class='button'>                            <a target='_blank' style='text-decoration: underline;'>                                <table border='0' cellpadding='0' cellspacing='0' align='center' style='max-width: 240px; min-width: 120px; border-collapse: collapse; border-spacing: 0; padding: 0;'>                                    <tr>                                        <td align='center' valign='middle' style='padding: 12px 24px;color: white;font-weight: bold;font-size: 20px;                                        margin: 0;  border-collapse: collapse; border-spacing: 0; border-radius: 4px; -webkit-border-radius: 4px; -moz-border-radius: 4px; -khtml-border-radius: 4px;' bgcolor='#0a5c80'>"+ serial +"  </td>                                    </tr>                                </table>                            </a>                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%;			padding-top: 30px;' class='line'>                            <hr color='#565F73' align='center' width='100%' size='1' noshade style='margin: 0; padding: 0;' />                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 13px; font-weight: 400; line-height: 150%;			padding-top: 10px;			padding-bottom: 20px;			color: #828999;			font-family: sans-serif;' class='footer'>                            You are receiving this email because of your relationship with POS Arqami . Please reconfirm your interest in receiving emails from us.If you do not wish to receive any more emails, you can unsubscribe here.                            <img width='1' height='1' border='0' vspace='0' hspace='0' style='margin: 0; padding: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: block;' src='https://raw.githubusercontent.com/konsav/email-templates/master/images/tracker.png'                            />                        </td>                    </tr>                </table>            </td>        </tr>    </table></body></html>";


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
        public IActionResult GetWorkStations(string Lang = "en")
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
