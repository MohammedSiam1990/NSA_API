using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Exceptions;
using MailKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pos.IService;
using POS.Core;
using POS.Core.Resources;
using POS.Data.Dto;
using Steander.Core.DTOs;


namespace StanderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAccountService _accountService;
        //private IMailService _mailService;
        private readonly IMapper _mapper;
        //private IConfiguration _configuration;
        public AuthController(IAccountService accountService,
            //IMailService mailService,
            IMapper mapper
            //IConfiguration configuration
            )
        {
            _accountService = accountService;
            //_mailService = mailService;
            _mapper = mapper;
            //_configuration = configuration;
        }

        // /api/auth/register
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
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
        // /api/auth/login
       
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

                    return BadRequest(result);
                }
                return BadRequest(new { message = lang.An_error_occurred_while_processing_your_request, success = false });

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return BadRequest(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

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
                    return BadRequest(new { message = lang.An_error_occurred_while_processing_your_request, success = false });
                
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
                    return BadRequest(new { message = lang.An_error_occurred_while_processing_your_request });
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return BadRequest(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }

        // api/auth/ForgetPassword
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
                    return Ok(result); // 200

                return BadRequest(result); // 400
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = lang.An_error_occurred_while_processing_your_request, ex = ex });

            }

        }

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
                    return Ok(new { success = false, Result=result });
                }

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return BadRequest(new { success = false, message = lang.An_error_occurred_while_processing_your_request });


        }


        //api/auth/getAllUsers
        //[HttpGet("GetAllUsers")]
        // public async Task<IActionResult> GetAllUsers()
        // {

        //     var result = await _accountService.GetAllUsersAsync();
        //     var resultDto = _mapper.Map<IList<UserDto>>(result);
        //     return Ok(resultDto);
        //     //return BadRequest();
        // }


        //api/auth/getUser
        [HttpGet("GetUser/{Id}")]
        public async Task<IActionResult> GetUser(string Id)
        {
            var result = await _accountService.GetUserAsync(Id);
            //var resultDto = _mapper.Map<UserDto>(result);
            return Ok(result);
            //return BadRequest();
        }

        [HttpPut("User/{Id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateUser(string Id , UserDto userDto)
        {
            var result= await _accountService.UpdateUserAsync(Id, userDto);
            return Ok(result);
        }

        [HttpDelete("User/{Id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            var result = await _accountService.DeletetUserAsync(Id);
            return Ok(result);
        }




    }
}