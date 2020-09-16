using POS.Entities;
using System;
using POS.Data.IRepository;
using POS.Data.Infrastructure;
using POS.API.Helpers;
using POS.Data.Helpers;
using POS.Core.Common;
using POS.Data.DataContext;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MailKit;
using System.Threading.Tasks;
using POS.Data.Dto;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Steander.Core.DTOs;
using Steander.Core.Entities;

namespace POS.Data.Repository
{
    //public class AccountRepository : Repository<AspNetUsers>, IAccountRepository
    //{
    //    MocRepository<Companies> MocCompany;
    //    MocRepository<Brands> MocBrand;
    //    public AccountRepository(IDatabaseFactory databaseFactory)
    //  : base(databaseFactory)
    //    {

    //        MocCompany = new MocRepository<Companies>(databaseFactory);
    //        MocBrand = new MocRepository<Brands>(databaseFactory);

    //    }


    //    private UserManager<ApplicationUser> _userManger;
    //    private IConfiguration _configuration;
    //    private IMailService _mailService;
    //    public AccountRepository(UserManager<ApplicationUser> userManager, IConfiguration configuration
    //        , IMailService mailService
    //        , IDatabaseFactory databaseFactory)
    //  : base(databaseFactory)
    //    {
    //        _userManger = userManager;
    //        _configuration = configuration;
    //        _mailService = mailService;
    //    }

    //    public async Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model)
    //    {
    //        if (model == null)
    //            throw new NullReferenceException("Reigster Model is null");

    //        if (model.Password != model.ConfirmPassword)
    //            return new UserManagerResponse
    //            {
    //                Message = "Confirm password doesn't match the password",
    //                IsSuccess = false,
    //            };
    //        string VerificationCode = RandomGenerator.RandomPassword();

    //        var identityUser = new ApplicationUser
    //        {
    //            Email = model.Email,
    //            UserName = model.Email,
    //            verificationCode = VerificationCode
    //        };

    //        var result = await _userManger.CreateAsync(identityUser, model.Password);

    //        if (result.Succeeded)
    //        {
    //            var confirmEmailToken = await _userManger.GenerateEmailConfirmationTokenAsync(identityUser);

    //            var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
    //            var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);

    //            string url = $"{_configuration["AppUrl"]}/api/auth/confirmemail?userid={identityUser.Id}&token={validEmailToken}";
    //            return new UserManagerResponse
    //            {
    //                Message = "User created successfully!",
    //                IsSuccess = true,
    //            };
    //        }

    //        return new UserManagerResponse
    //        {
    //            Message = "User did not create",
    //            IsSuccess = false,
    //            Errors = result.Errors.Select(e => e.Description)
    //        };

    //    }

    //    public async Task<LoginResponseDto> LoginUserAsync(LoginViewModel model)
    //    {
    //        var user = await _userManger.FindByEmailAsync(model.Email);

    //        if (user == null)
    //        {
    //            return new LoginResponseDto
    //            {
    //                message = "Username or password is incorrect",
    //                status = false,
    //            };
    //        }

    //        if (user.EmailConfirmed == false)
    //        {
    //            return new LoginResponseDto
    //            {
    //                message = "Can't Login ,Please Confirm Email First",
    //                status = false
    //            };
    //        }
    //        var result = await _userManger.CheckPasswordAsync(user, model.Password);

    //        if (!result)
    //            return new LoginResponseDto
    //            {
    //                message = "Invalid password",
    //                status = false,
    //            };

    //        var claims = new[]
    //        {
    //            new Claim("Email", model.Email),
    //            new Claim(ClaimTypes.NameIdentifier, user.Id),
    //        };

    //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

    //        var token = new JwtSecurityToken(
    //            issuer: _configuration["AuthSettings:Issuer"],
    //            audience: _configuration["AuthSettings:Audience"],
    //            claims: claims,
    //            expires: DateTime.Now.AddDays(30),
    //            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

    //        string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
    //        return new LoginResponseDto
    //        {
    //            UserId = user.Id,
    //            UserName = user.UserName,
    //            Email = user.Email,
    //            Token = tokenAsString,
    //            message = "Login Successfully",
    //            status = true
    //        };
    //        //return new LoginResponseDto
    //        //{
    //        //    Token = tokenAsString,
    //        //    UserName = "dd",
    //        //    Email = user.Email
    //        //};


    //    }

    //    public async Task<UserManagerResponse> ConfirmEmailAsync(ConfirmEmail model)
    //    {
    //        var user = await _userManger.FindByEmailAsync(model.Email);
    //        if (user == null)
    //            return new UserManagerResponse
    //            {
    //                IsSuccess = false,
    //                Message = "User not found"
    //            };

    //        if (model.VerficationCode == user.verificationCode)
    //        {
    //            user.EmailConfirmed = true;
    //            var result = await _userManger.UpdateAsync(user);


    //            return new UserManagerResponse
    //            {
    //                Message = "Email confirmed successfully!",
    //                IsSuccess = true,
    //            };
    //        }
    //        else
    //        {
    //            return new UserManagerResponse
    //            {
    //                IsSuccess = false,
    //                Message = "Email did not confirm",

    //            };
    //        }
    //    }

    //    public async Task<UserManagerResponse> ForgetPasswordAsync(ForgetPasswordModel forgetPasswordModel)
    //    {
    //        var user = await _userManger.FindByEmailAsync(forgetPasswordModel.Email);
    //        if (user == null)
    //            return new UserManagerResponse
    //            {
    //                IsSuccess = false,
    //                Message = "No user associated with email",
    //            };

    //        var token = await _userManger.GeneratePasswordResetTokenAsync(user);
    //        var encodedToken = Encoding.UTF8.GetBytes(token);
    //        var validToken = WebEncoders.Base64UrlEncode(encodedToken);
    //        string url = $"{_configuration["AppUrl"]}/ResetPassword?email={forgetPasswordModel.Email}&token={validToken}";
    //        var body = "<html><body>" +
    //                                    "<h2>Password reset</h2>" +
    //                        $"<p>Hi {user.UserName}, <a href='{url}'> please click this link to reset your password </a></p>" +
    //                         "</body></html>";


    //        return new UserManagerResponse
    //        {
    //            IsSuccess = true,
    //            Message = "Reset password URL has been sent to the email successfully!"
    //        };
    //    }

    //    public async Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordViewModel model)
    //    {
    //        var user = await _userManger.FindByEmailAsync(model.Email);
    //        if (user == null)
    //            return new UserManagerResponse
    //            {
    //                IsSuccess = false,
    //                Message = "No user associated with email",
    //            };

    //        if (model.NewPassword != model.ConfirmPassword)
    //            return new UserManagerResponse
    //            {
    //                IsSuccess = false,
    //                Message = "Password doesn't match its confirmation",
    //            };
    //        var token = await _userManger.GeneratePasswordResetTokenAsync(user);
    //        var encodedToken = Encoding.UTF8.GetBytes(token);
    //        var validToken = WebEncoders.Base64UrlEncode(encodedToken);
    //        var decodedToken = WebEncoders.Base64UrlDecode(token);
    //        string normalToken = Encoding.UTF8.GetString(decodedToken);

    //        var result = await _userManger.ResetPasswordAsync(user, token, model.NewPassword);

    //        if (result.Succeeded)
    //            return new UserManagerResponse
    //            {
    //                Message = "Password has been reset successfully!",
    //                IsSuccess = true,
    //            };

    //        return new UserManagerResponse
    //        {
    //            Message = "Something went wrong",
    //            IsSuccess = false,
    //            Errors = result.Errors.Select(e => e.Description),
    //        };
    //    }

    //    public async Task<IList<ApplicationUser>> GetAllUsersAsync()
    //    {
    //        var users = await _userManger.Users.ToListAsync();
    //        return users;
    //    }

    //    public async Task<ApplicationUser> GetUserAsync(string Id)
    //    {
    //        var user = await _userManger.FindByIdAsync(Id);
    //        return user;
    //    }

    //    public async Task<UserManagerResponse> UpdateUserAsync(string Id, UserDto model)
    //    {
    //        var user = await _userManger.FindByIdAsync(Id);
    //        user.Name = model.FirstName;
    //        user.Email = model.Email;
    //        user.UserName = model.UserName;
    //        var result = await _userManger.UpdateAsync(user);
    //        //return null;
    //        if (result.Succeeded)
    //        {
    //            return new UserManagerResponse
    //            {
    //                Message = "Update Successfully!",
    //                IsSuccess = true,
    //            };
    //        }
    //        return new UserManagerResponse
    //        {
    //            Message = "Something went wrong",
    //            IsSuccess = false,
    //            Errors = result.Errors.Select(e => e.Description),
    //        };
    //    }

    //    public async Task<UserManagerResponse> DeletetUserAsync(string Id)
    //    {
    //        var user = await _userManger.FindByIdAsync(Id);
    //        var result = await _userManger.DeleteAsync(user);
    //        if (result.Succeeded)
    //        {
    //            return new UserManagerResponse
    //            {
    //                Message = "Delete Successfully!",
    //                IsSuccess = true,
    //            };
    //        }
    //        return new UserManagerResponse
    //        {
    //            Message = "Something went wrong",
    //            IsSuccess = false,
    //            Errors = result.Errors.Select(e => e.Description),
    //        };
    //    }



    //}
}