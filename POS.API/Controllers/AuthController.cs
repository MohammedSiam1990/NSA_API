﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using MailKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pos.IService;
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



            if (ModelState.IsValid)
            {
                var result = await _accountService.RegisterUserAsync(model);

                if (result.IsSuccess)
                    return Ok(result); // Status Code: 200 
                else
                return BadRequest(result);
            }
            else
            {
                var result = new { message = lang.An_error_occurred_while_processing_your_request, success = false };

                return BadRequest(result);
            }
      
        }
        // /api/auth/login
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.LoginUserAsync(model);

                if (result.status)
                {
                    //await _mailService.SendEmailAsync(model.Email, "New login", "<h1>Hey!, new login to your account noticed</h1><p>New login to your account at " + DateTime.Now + "</p>");
                    return Ok(result);
                }

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }
        //[AllowAnonymous]
        //[HttpGet("testMail")]
        //public IActionResult TestMAil()
        //{
        //    return Ok(res);
        //}

        // /api/auth/confirmemail
        //[AllowAnonymous]
        //[HttpPost("ConfirmEmail")]
        //public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmail model)
        //{
        //    if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.VerficationCode))
        //        return NotFound();

        //    var result = await _accountService.ConfirmEmailAsync(model);

        //    if (result.IsSuccess)
        //    {
        //        return Ok(result);
        //    }

        //    return BadRequest(result);
        //}

        // api/auth/forgetpassword
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordModel forgetPasswordModel)
        {
            if (string.IsNullOrEmpty(forgetPasswordModel.Email))
                return NotFound();

            var result = await _accountService.ForgetPasswordAsync(forgetPasswordModel);

            if (result.IsSuccess)
                return Ok(result); // 200

            return BadRequest(result); // 400
        }


        // api/auth/resetpassword
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromForm]ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.ResetPasswordAsync(model);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
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