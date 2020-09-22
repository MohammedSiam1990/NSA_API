using POS.Entities;
using Pos.IService;
using POS.IService.Base;
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
            IConfiguration configuration,
          IMailService _mailService
            )

        {
            _userManger = userManager;
            CompaniesService = _CompaniesService;
            _configuration = configuration;
            mailService = _mailService;
            emailConfig = _emailConfig;
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
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(model.Lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(model.Lang);


            if (model == null)
            {
                return new UserManagerResponse
                {
                    message = lang.Reigster_Model_is_null,
                    success = false,
                };
            }



            if (string.IsNullOrWhiteSpace(model.Email))
            {
                return new UserManagerResponse
                {
                    message = lang.Missing_username,
                    success = false,
                };

            }

            if (string.IsNullOrWhiteSpace(model.Password))
            {
                return new UserManagerResponse
                {
                    message = lang.Missing_password,
                    success = false,
                };
            }

            if (model.Password.Length < 6)
            {
                return new UserManagerResponse
                {
                    message = lang.Password_length_should_be_6_characters_or_more,
                    success = false,
                };
            }

            if (model.Password != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    message = lang.PasswordNotMatch,
                    success = false,
                };



            var appUser = await _userManger.FindByEmailAsync(model.Email);
            if (appUser != null && appUser.Email == model.Email)
            {
                return new UserManagerResponse
                {
                    message = lang.Either_username_and_or_email_already_exists,
                    success = false,
                };
            }

            appUser = await _userManger.FindByNameAsync(model.Username);
            if (appUser != null && appUser.UserName == model.Username)
            {
                return new UserManagerResponse
                {
                    message = lang.Either_username_and_or_email_already_exists,
                    success = false,
                };

            }
            string VerificationCode = RandomGenerator.RandomPassword();

            var company = new Companies
            {
                CountryId = model.CountryId,
                CompanyName = model.CompanyName,
                CompanyNameAr = model.CompanyNameAr,
                CompanyEmail = model.Email,
                StatusId = 1,
                ImageName = model.ImageName,
                CreationDate = DateTime.Now,
                
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


                var Body = lang.Please_activate_your_account_by_clicking + "<a href=\"" + callbackUrl + "\"> " + lang.Here + "</a>";
                
                var Subject = lang.Activare_your_account;

                //string url = $"{emailConfig.AppUrl}/api/auth/confirmemail?userid={identityUser.Id}&token={validEmailToken}";
                bool isMessageSent = mailService.SendEmailAsync(emailConfig.SmtpServer, emailConfig.Port, false, emailConfig.From, identityUser.Email, Subject, Body, emailConfig.From, emailConfig.Password);

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
                    return new UserManagerResponse
                    {
                        message = lang.Cant_send_activation_email_please_try_registration_later,
                        success = false,
                    };
                    
                }

                return new UserManagerResponse
                {

                    message = lang.Your_registration_completed_successfully + ", " + lang.Please_check_your_email_to_activtate_your_email,
                    //EmailConfirmed = User.EmailConfirmed,
                    success = true,
                };
            }

            return new UserManagerResponse
            {

                message = lang.An_error_occurred_while_processing_your_request,
                success = false,
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
            var User = await _userManger.FindByIdAsync(userId);
            var result = _userManger.ConfirmEmailAsync(User, code);
            return true;
        }

        public async Task<UserManagerResponse> ForgetPasswordAsync(String Email, string Lang)
        {

            var user = await _userManger.FindByEmailAsync(Email);
            if (user == null)
            {
                throw new AppException(lang.Invalid_email);

            }
            else if (!(await _userManger.IsEmailConfirmedAsync(user)))
            {
                throw new AppException(lang.Confirm_your_email);
            }

            var Resetcode = await _userManger.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = emailConfig.AppUrl + "?Resetcode=" + Resetcode + "&Lang=" + Lang;

            var Body = lang.To_reset_your_password_click + "<a href=\"" + callbackUrl + "\"> " + lang.Here + "</a>";
            var Subject = lang.Reset_your_password;
            bool isMessageSent = false;
            isMessageSent = mailService.SendEmailAsync(emailConfig.SmtpServer, emailConfig.Port, false, emailConfig.From, Email, Subject, Body, emailConfig.From, emailConfig.Password);

            if (isMessageSent == false)
            {
                throw new AppException(lang.Cant_send_forgot_password_email_please_try_later);
            }
            return new UserManagerResponse
            {
                success = true,
                message = lang.Please_check_your_email_to_reset_your_password,
            };
        }

        public IList<ApplicationUser> GetAllUsersAsync()
        {
            var users = _userManger.Users.ToList();
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
                    message = "Update Successfully!",
                    success = true,
                };
            }
            return new UserManagerResponse
            {
                message = "Something went wrong",
                success = false,
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
                    message = "Delete Successfully!",
                    success = true,
                };
            }
            return new UserManagerResponse
            {
             
                message =    lang.An_error_occurred_while_processing_your_request,
                success = false,
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
                    message = lang.Invalid_email,
                    success = false,
                };
            }
            string Resetcode;
            Resetcode = model.Resetcode.Replace(' ', '+');
            var result = await _userManger.ResetPasswordAsync(user, Resetcode, model.Password);
            if (result.Succeeded)
            {
                user.Password = model.Password;
                await _userManger.UpdateAsync(user);
                return new UserManagerResponse
                {
                    message = lang.Your_password_has_been_reset_Please,
                    success = true,
                };
            }
            return new UserManagerResponse
            {
                message = lang.An_error_occurred_while_processing_your_request,
                success = false,
            };

        }


        public async Task<UserManagerResponse> ChangePassword(string userName, string OldPassword, string NewPassword)
        {
            ApplicationUser user =await _userManger.FindByNameAsync(userName);
            var result =await _userManger.ChangePasswordAsync(user, OldPassword, NewPassword);
            if (!result.Succeeded)
            {

                foreach (var error in result.Errors)
                {
                    if (error.Description == "Incorrect password.")
                    {
                        return new UserManagerResponse {message= lang.Incorrect_current_password,success = false };
                    }
                    else
                    {
                        return new UserManagerResponse { message = lang.An_error_occurred_while_processing_your_request, success = false };
                    }
                }
            }
            return new UserManagerResponse
            {
                message = lang.Your_password_has_been_changed,
                success = false,
            };
        }
    }
}
