using AutoMapper;
using EmailService;
using Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSR.IService;
using NSR.Core;
using NSR.Core.Resources;
using NSR.Data;
using NSR.Data.Dto;
using NSR.Data.Dto.Account;
using Steander.Core.DTOs;
using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;


namespace StanderApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private IAccountService _accountService;
        //private IMailService _mailService;
        private readonly IMapper _mapper;
        EmailConfiguration emailConfig;
        public AuthController(IAccountService accountService, UserManager<ApplicationUser> userManager,
             EmailConfiguration _emailConfig,
            IMapper mapper
            )
        {
            _accountService = accountService;
            //_mailService = mailService;
            _mapper = mapper;
            emailConfig = _emailConfig;
            _userManager = userManager;

        }

        // /api/auth/register
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.AppUrl = emailConfig.AppUrl;
                    var result = await _accountService.RegisterUserAsync(model);
                    return Ok(result);
                }
                else
                {
                    return Ok(new { message = lang.An_error_occurred_while_processing_your_request, success = false });
                }
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { message = lang.An_error_occurred_while_processing_your_request, success = false });
        }
       


        [HttpGet("GetUsers")]
        public IActionResult GetUsers(int UserType, int? CompanyID = null, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = _accountService.GetAllUsersAsync(UserType, CompanyID);
                if (data != null)
                {
                    if (data.Count() == 0)
                    {
                        return Ok(new { success = true, message = lang.No_data_available, datalist = data });
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

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginViewModel model)
        {
            try
            {
                model.Lang = Utility.CheckLanguage(model.Lang);
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(model.Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(model.Lang);

                if (string.IsNullOrWhiteSpace(model.Username))
                {
                    return Ok(new { message = lang.Missing_username, success = false });
                }

                if (string.IsNullOrWhiteSpace(model.Password))
                {
                    return Ok(new { message = lang.Missing_password, success = false });
                }

                if (model.Password.Length < 6)
                {
                    return Ok(new { message = lang.Password_length_should_be_6_characters_or_more, success = false });
                }


                if (!ModelState.IsValid)
                {
                    return Ok(new { message = lang.An_error_occurred_while_processing_your_request, success = false });
                }

                if (ModelState.IsValid)
                {
                    var result = await _accountService.LoginUserAsync(model);

                    if (result.status)
                    {
                        return Ok(result);
                    }

                    return Ok(result);
                }
                return Ok(new { message = lang.An_error_occurred_while_processing_your_request, success = false });

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }

        [AllowAnonymous]
        [HttpPost("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code, string Lang)
        {
            try
            {
                if (Lang == null)
                    Lang = "en";
                code = code.Replace(' ', '+');
                Lang = Utility.CheckLanguage(Lang);
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
                if (userId == "" || code == "")
                {
                    return Ok(new { message = lang.An_error_occurred_while_processing_your_request, success = false });

                }

                if (string.IsNullOrWhiteSpace(userId))
                {
                    return Ok(new { message = lang.An_error_occurred_while_processing_your_request, success = false });
                }

                if (string.IsNullOrWhiteSpace(code))
                {
                    return Ok(new { message = lang.An_error_occurred_while_processing_your_request, success = false });
                }


                var result = _accountService.ConfirmEmailAsync(userId, code);
                if (await result)
                    return Ok(new { message = lang.Your_registration_completed_successfully, success = true });
                else
                    return Ok(new { message = lang.An_error_occurred_while_processing_your_request, success = false });
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }

        // api/auth/ForgetPassword
        [AllowAnonymous]
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(String Email, string Lang)
        {
            try
            {
                Lang = Utility.CheckLanguage(Lang);
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
                if (string.IsNullOrEmpty(Email))
                    return NotFound();

                var result = await _accountService.ForgetPasswordAsync(Email, Lang);

                if (result.success)
                    return Ok(new { message = result.message, success = result.success });
                else
                    return Ok(new { message = result.message, success = result.success });
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { message = lang.An_error_occurred_while_processing_your_request, success = false });

        }
        // api/auth/ForgetPassword


        [AllowAnonymous]
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model, string Lang = "en")
        {
            try
            {
                Lang = Utility.CheckLanguage(Lang);
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                if (!ModelState.IsValid)
                {
                    return Ok(new { success = false, message = lang.Missing_data });

                }
                if (ModelState.IsValid)
                {
                    var result = await _accountService.ResetPassword(model);

                    if (result.success)
                        return Ok(new { message = result.message, success = result.success });
                    else
                        return Ok(new { message = result.message, success = result.success });
                }

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });


        }

        [AllowAnonymous]
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUserAsync([FromBody]UserModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.AppUrl = emailConfig.AppUrl;
                    var result = await _accountService.AddUserAsync(model);
                    return Ok(result);
                }
                else
                {
                    return Ok(new { message = lang.An_error_occurred_while_processing_your_request, success = false });
                }
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { message = lang.An_error_occurred_while_processing_your_request, success = false });
        }
        //api/auth/getAllUsers
        //[HttpGet("GetAllUsers")]
        // public async Task<IActionResult> GetAllUsers()
        // {

        //     var result = await _accountService.GetAllUsersAsync();
        //     var resultDto = _mapper.Map<IList<UserDto>>(result);
        //     return Ok(resultDto);
        //     //return Ok();
        // }


        //api/auth/getUser
        [HttpGet("GetUser/{Id}")]
        public async Task<IActionResult> GetUser(string Id)
        {
            try
            {
                var result = await _accountService.GetUserAsync(Id);
                //var resultDto = _mapper.Map<UserDto>(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }

        [AllowAnonymous]
        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUserAsync([FromBody]UserModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.AppUrl = emailConfig.AppUrl;
                    var result = await _accountService.UpdateUserAsync(model);
                    return Ok(result);
                }
                else
                {
                    return Ok(new { message = lang.An_error_occurred_while_processing_your_request, success = false });
                }
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { message = lang.An_error_occurred_while_processing_your_request, success = false });
        }


        [AllowAnonymous]
        [HttpPost("SaveUser")]
        public async Task<IActionResult> SaveUser([FromBody]CreateUserModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _accountService.SaveUser(model);
                    return Ok(result);
                }
                else
                {
                    return Ok(new { message = lang.An_error_occurred_while_processing_your_request, success = false });
                }
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { message = lang.An_error_occurred_while_processing_your_request, success = false });
        }


        [HttpDelete("User/{Id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            try
            {
                var result = await _accountService.DeletetUserAsync(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            try
            {
                model.Lang = Utility.CheckLanguage(model.Lang);

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(model.Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(model.Lang);

                if (string.IsNullOrWhiteSpace(model.OldPassword))
                {
                    return Ok(new { message = lang.Missing_old_password, success = false });
                }

                if (string.IsNullOrWhiteSpace(model.NewPassword))
                {
                    return Ok(new { message = lang.Missing_new_password, success = false });
                }

                if (model.OldPassword.Length < 6)
                {
                    return Ok(new { message = lang.Old_password_length_should_be_6_characters_or_more, success = false });
                }


                if (model.NewPassword.Length < 6)
                {
                    return Ok(new { message = lang.New_password_length_should_be_6_characters_or_more, success = false });
                }

                if (!ModelState.IsValid)
                {
                    return Ok(new { message = lang.An_error_occurred_while_processing_your_request, success = false });
                }
                var UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await _accountService.ChangePassword(UserID, model.OldPassword, model.NewPassword);

                if (result.success)
                    return Ok(new { message = result.message, success = result.success });
                else
                    return Ok(new { message = result.message, success = result.success });

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { message = lang.An_error_occurred_while_processing_your_request, success = false });
        }

        [HttpPost("IdentityApplicationUser")]

        public async Task<IActionResult> IdentityApplicationUser()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _accountService.IdentityApplicationUser(userId);
                return Ok(user);

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }
        [AllowAnonymous]
        [HttpPost("LogOut")]

        public async Task<IActionResult> LogOut()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _accountService.Logout(userId);
                return Ok(user);

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }
    }
}