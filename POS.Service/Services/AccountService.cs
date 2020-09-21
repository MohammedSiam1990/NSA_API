using POS.Entities;
using Pos.IService;
using POS.IService.Base;
using POS.Dto;
using System;
using POS.Core.Common;
using System.Linq.Dynamic;
using POS.Data.Dto;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Claims;
using Steander.Core.DTOs;
using POS.Data.DataContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Steander.Core.Entities;
using System.Threading;
using System.Globalization;
using EmailService;
using System.IO;
using System.Reflection;
using POS.Core.Resources;
using MailKit;
using POS.API.Helpers;

namespace Pos.Service
{
    public class AccountService : BaseService, IAccountService
    {

        private UserManager<ApplicationUser> _userManger;
        private IConfiguration _configuration;
       private IMailService mailService;
        EmailConfiguration emailConfig;
        private ICompaniesService CompaniesService;
        public AccountService(UserManager<ApplicationUser> userManager,
             ICompaniesService _CompaniesService,
            EmailConfiguration _emailConfig,
            IConfiguration configuration ,
          IMailService _mailService
            )
      
        {
            _userManger = userManager;
            CompaniesService = _CompaniesService;
            _configuration = configuration;
             mailService  = _mailService;
            emailConfig =_emailConfig;
        }
        public static string CheckLanguage(string lang)
        {
            try
            {
                if (lang.ToLower() == "en")
                    return "en";
                if (lang.ToLower() == "ar")
                    return "ar";
                return "en";
            }
            catch (Exception ex)
            {
              ExceptionError(ex);
            }
            return "en";
        }
        public static void ExceptionError(Exception ex)
        {

            try
            {
                var file_name = Environment.CurrentDirectory + "/LOG/log.txt";// HostingEnvironment.MapPath(@"~/LOG/log.txt");
                if (!Directory.Exists(Environment.CurrentDirectory + "/LOG/"))
                    // System.Web.Hosting.HostingEnvironment.MapPath(@"~/LOG")))
                    
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + "/LOG/");
                }
                if (!System.IO.File.Exists(file_name))
                {
                    FileStream stream = System.IO.File.Create(file_name);
                    stream.Close();
                }
                System.IO.File.WriteAllText(file_name, System.IO.File.ReadAllText(file_name) + DateTime.Now + Environment.NewLine + ex.Message + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + Environment.NewLine);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
   

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model)
        {
            model.Lang = CheckLanguage(model.Lang);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(model.Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(model.Lang);


            if (model == null)
                 throw new AppException(lang.Reigster_Model_is_null);
            if (string.IsNullOrWhiteSpace(model.Email))
            {
                 throw new AppException(lang.Missing_username);
            }

            if (string.IsNullOrWhiteSpace(model.Password))
            {
                throw new AppException(lang.Missing_password);
            }

            if (model.Password.Length < 6)
            {
                throw new AppException(lang.Password_length_should_be_6_characters_or_more);
            }

            if (model.Password != model.ConfirmPassword)
              throw new AppException(lang.PasswordNotMatch);



            var appUser = await _userManger.FindByEmailAsync(model.Email);
            if (appUser != null && appUser.Email == model.Email)
            {

                throw new AppException(lang.Either_username_and_or_email_already_exists );
            }

            appUser = await _userManger.FindByNameAsync(model.Username);
            if (appUser != null && appUser.UserName == model.Username)
            {
                throw new AppException(lang.Either_username_and_or_email_already_exists);
            }
            string VerificationCode = RandomGenerator.RandomPassword();

            var company = new Companies {
                CountryId = model.CountryId,
                CompanyName = model.CompanyName,
                CompanyNameAr = model.CompanyNameAr,
                CompanyEmail = model.Email,
                StatusId = 1,
                ImageName = model.ImageName,
                CreationDate = DateTime.Now
            };
            PosService.CompaniesRepository.AddCompany(company);

            var identityUser = new ApplicationUser()
            {
                UserName = model.Username,
                Email = model.Email,
                CreateDate = DateTime.Now,
                Name = model.Name,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                EmailConfirmed = false,
                IsSuperAdmin = true,
                LockoutEnabled = false,
                  CompanyId = company.CompanyId,
                UserType = 1,
               // VerificationCode = VerificationCode
            };

            var result = await _userManger.CreateAsync(identityUser, model.Password);

            if (result.Succeeded)
            {
                var confirmEmailToken = await _userManger.GenerateEmailConfirmationTokenAsync(identityUser);

                var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
                var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);

                var User = await _userManger.FindByEmailAsync(model.Email);

                string code = await this._userManger.GenerateEmailConfirmationTokenAsync(User);
                var callbackUrl = emailConfig.AppUrl + "?userId=" + User.Id + "&code=" + code + "&lang=" + model.Lang;


                var Body = lang.Please_activate_your_account_by_clicking + " <a href=\"" + callbackUrl + "\">" + lang.Here + "</a>";
                var Subject = lang.Activare_your_account;

                string url = $"{emailConfig.AppUrl}/api/auth/confirmemail?userid={identityUser.Id}&token={validEmailToken}";
               bool isMessageSent =  mailService.SendEmailAsync(emailConfig.SmtpServer,emailConfig.Port,false ,emailConfig.From, identityUser.Email, Subject, Body, emailConfig.From, emailConfig.Password);

                if (isMessageSent == false)
                {
                    try
                    {
                        var response = await DeletetUserAsync(User.Id);
                    }
                    catch (Exception ex)
                    {

                        ExceptionError(ex);
                    }
                    throw new AppException(lang.Cant_send_activation_email_please_try_registration_later);
                }

       

                return new UserManagerResponse
                {
                     
                Message =lang.Your_registration_completed_successfully + ", " + lang.Please_check_your_email_to_activtate_your_email,
                 //EmailConfirmed = User.EmailConfirmed,
                    IsSuccess = true,
                };
            }

            return new UserManagerResponse
            {

                Message = lang.An_error_occurred_while_processing_your_request,
                IsSuccess = false,
            };

        }
   
        public async Task<LoginResponseDto> LoginUserAsync(LoginViewModel model)
        {

            var user = await _userManger.FindByEmailAsync(model.Username);


            if (user == null)
            {
                throw new AppException(lang.The_username_or_password_is_incorrect);
            }

            if (!user.EmailConfirmed)
            {
                throw new AppException(lang.Your_account_is_not_activated_please_activate_it);
            }


            if (user.LockoutEnabled == true)
            {
                throw new AppException(lang.Your_account_is_locked_please_try_later);
            }

            var result = await _userManger.CheckPasswordAsync(user, model.Password);

            if (!result)
                return new LoginResponseDto
                {
                    message = lang.The_username_or_password_is_incorrect,
                    status = false,
                };
            var claims = new[]
            {
                new Claim("Username", model.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
            var Company = CompaniesService.GetCompany(user.CompanyId);


            return new LoginResponseDto
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Token = tokenAsString,
                message = "Login Successfully",
                status = true,
                companyId = user.CompanyId.ToString(),
                Name = user.Name,
                CompanyNameEn = Company.CompanyName,
                CompanyNameAr = Company.CompanyNameAr
            };
        }

        public async Task<bool> ConfirmEmailAsync(string userId, string code)
        {
                var User = await _userManger.FindByEmailAsync(userId);
                var result = _userManger.ConfirmEmailAsync(User,  code);
                return true;
        }

        public async Task<UserManagerResponse> ForgetPasswordAsync(ForgetPasswordModel forgetPasswordModel)
        {
            var user = await _userManger.FindByEmailAsync(forgetPasswordModel.Email);
            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "No user associated with email",
                };

            var token = await _userManger.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);
            string url = $"{_configuration["AppUrl"]}/ResetPassword?email={forgetPasswordModel.Email}&token={validToken}";
            var body = "<html><body>" +
                                        "<h2>Password reset</h2>" +
                            $"<p>Hi {user.UserName}, <a href='{url}'> please click this link to reset your password </a></p>" +
                             "</body></html>";


            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = "Reset password URL has been sent to the email successfully!"
            };
        }

        public async Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordViewModel2 model)
        {
            var user = await _userManger.FindByEmailAsync(model.Email);
            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "No user associated with email",
                };

            if (model.NewPassword != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Password doesn't match its confirmation",
                };
            var token = await _userManger.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);
            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManger.ResetPasswordAsync(user, token, model.NewPassword);

            if (result.Succeeded)
                return new UserManagerResponse
                {
                    Message = "Password has been reset successfully!",
                    IsSuccess = true,
                };

            return new UserManagerResponse
            {
                Message = "Something went wrong",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description),
            };
        }


        public IList<ApplicationUser> GetAllUsersAsync()
        {
            var users =  _userManger.Users.ToList();
            return users;
        }

        public async Task<ApplicationUser> GetUserAsync(string Id)
        {
            var user = await _userManger.FindByIdAsync(Id);
            return user;
        }

        public async Task<UserManagerResponse> UpdateUserAsync(string Id, UserDto model)
        {
            var user = await _userManger.FindByIdAsync(Id);
            //user.FirstName = model.FirstName;
            user.Email = model.Email;
            user.UserName = model.UserName;
            var result = await _userManger.UpdateAsync(user);
            //return null;
            if (result.Succeeded)
            {
                return new UserManagerResponse
                {
                    Message = "Update Successfully!",
                    IsSuccess = true,
                };
            }
            return new UserManagerResponse
            {
                Message = "Something went wrong",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description),
            };
        }

        public async Task<UserManagerResponse> DeletetUserAsync(string Id)
        {
            var user = await _userManger.FindByIdAsync(Id);
            var result = await _userManger.DeleteAsync(user);
            if (result.Succeeded)
            {
                return new UserManagerResponse
                {
                    Message = "Delete Successfully!",
                    IsSuccess = true,
                };
            }
            return new UserManagerResponse
            {
                Message = "Something went wrong",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description),
            };
        }

        public async Task<UserManagerResponse> ResetPassword(ResetPasswordViewModel model)
        {

            var user = await _userManger.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = lang.Invalid_email,
                    IsSuccess = false,
                };
            }
            var token = await _userManger.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);
            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);
            var result = await _userManger.ResetPasswordAsync(user, token, model.Password);

            if (result.Succeeded)
                return new UserManagerResponse
                {
                    Message = lang.Your_password_has_been_reset_Please,
                    IsSuccess = true,
                };

            return new UserManagerResponse
            {
                Message = "Something went wrong",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description),
            };

        }
    }
}
