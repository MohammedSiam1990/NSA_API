using EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Pos.IService;
using POS.Core.Resources;
using POS.Data.Dto;
using POS.Data.Dto.Account;
using POS.Entities;
using POS.IService.Base;
using Steander.Core.DTOs;
using Steander.Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Service
{
    public class AccountService : BaseService, IAccountService
    {

        private UserManager<ApplicationUser> _userManger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IConfiguration _configuration;
        private IMailService mailService;
        EmailConfiguration emailConfig;
        private ICompaniesService CompaniesService;
        private IBrandService BrandService;
        public AccountService(UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
             ICompaniesService _CompaniesService,
             IBrandService _brandService,
            EmailConfiguration _emailConfig,
            IConfiguration configuration,
          IMailService _mailService
            )

        {
            _userManger = userManager;
            _signInManager = signInManager;
            CompaniesService = _CompaniesService;
            _configuration = configuration;
            mailService = _mailService;
            emailConfig = _emailConfig;
            BrandService = _brandService;
        }

        public static void ExceptionError(Exception ex)
        {
            try
            {
                var file_name = Path.Combine(@"LOG/log.txt");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), file_name);

                if (!Directory.Exists(Path.Combine(@"LOG")))
                {
                    Directory.CreateDirectory(Path.Combine(@"LOG"));
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

            var company = new Companies
            {
                CountryId = model.CountryId,
                CompanyName = model.CompanyName,
                CompanyNameAr = model.CompanyNameAr,
                CompanyEmail = model.Email,
                StatusId = 6,
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
                UserType = 1
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
                var callbackUrl = model.AppUrl + "?userId=" + User.Id + "&code=" + code + "&lang=" + model.Lang;


                //var Body = lang.Please_activate_your_account_by_clicking + "<a href=\"" + callbackUrl + "\"> " + lang.Here + "</a>";
                var Body = "<html xmlns='http://www.w3.org/1999/xhtml'> <head> <meta http-equiv='content-type' content='text/html; charset=utf-8'> <meta name='viewport' content='width=device-width, initial-scale=1.0;'> <meta name='format-detection' content='telephone=no'> <style> body { margin: 0; padding: 0; min-width: 100%; width: 100% !important; height: 100% !important; } body, table, td, div, p, a { -webkit-font-smoothing: antialiased; text-size-adjust: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; line-height: 100%; } table, td { mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse !important; border-spacing: 0; } img { border: 0; line-height: 100%; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; } #outlook a { padding: 0; } .ReadMsgBody { width: 100%; } .ExternalClass { width: 100%; } .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div { line-height: 100%; } @media all and (min-width: 560px) { .container { border-radius: 8px; -webkit-border-radius: 8px; -moz-border-radius: 8px; -khtml-border-radius: 8px; } } a, a:hover { color: #0a5c80; } .footer a, .footer a:hover { color: #828999; } </style> <title></title> </head> <body topmargin='0' rightmargin='0' bottommargin='0' leftmargin='0' marginwidth='0' marginheight='0' width='100%' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; width: 100%; height: 100%; -webkit-font-smoothing: antialiased; text-size-adjust: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; line-height: 100%; background-color: #ffff; color: #0a5c80;' bgcolor='#fff' text='##0a5c80'> <table width='100%' align='center' border='0' cellpadding='0' cellspacing='0' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; width: 100%;' class='background'> <tbody> <tr> <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0;' bgcolor='#fff'> <table border='0' cellpadding='0' cellspacing='0' align='center' width='500' style='border-collapse: collapse; border-spacing: 0; padding: 0; width: inherit; max-width: 500px;' class='wrapper'> <tbody> <tr> <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; padding-top: 20px; padding-bottom: 20px;'> <div style='display: none; visibility: hidden; overflow: hidden; opacity: 0; font-size: 1px; line-height: 1px; height: 0; max-height: 0; max-width: 0; color: #2D3445;' class='preheader'> </div> </td> </tr> <tr> <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-top: 0px;' class='hero'> <a target='_blank' style='text-decoration: none;' href='#'> <img border='0' vspace='0' hspace='0' src='http://pos.opos.me/assets/images/arqami_logo.svg' alt='Please enable images to view this content' title='Hero Image' width='340' style=' width: 87.5%; max-width: 340px; color: #0a5c80; font-size: 13px; margin: 0; padding: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: block;'> </a> </td> </tr> <tr> <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 14px; font-weight: 400; line-height: 150%; letter-spacing: 2px; padding-top: 27px; padding-bottom: 0; color: #0a5c80; font-family: sans-serif;' class='supheader'> Welcome To </td> </tr> <tr> <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 24px; font-weight: bold; line-height: 130%; padding-top: 5px; color: #0a5c80; font-family: sans-serif;' class='header'> POS Arqami System </td> </tr> <tr> <td align='right' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 17px; font-weight: 400; line-height: 160%; padding-top: 15px; color: #0a5c80; font-family: sans-serif;' class='paragraph'> Dear User , Welcome To POS Arqami System, your account has been created with login information below </td> </tr> <tr> <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; padding-top: 25px; padding-bottom: 5px;' class='button'> <a href=" + callbackUrl + @" target='_blank' style='text-decoration: underline;'> <table border='0' cellpadding='0' cellspacing='0' align='center' style='max-width: 240px; min-width: 120px; border-collapse: collapse; border-spacing: 0; padding: 0;'> <tbody> <tr> <td align='center' valign='middle' style='padding: 12px 24px; margin: 0; text-decoration: underline; border-collapse: collapse; border-spacing: 0; border-radius: 4px; -webkit-border-radius: 4px; -moz-border-radius: 4px; -khtml-border-radius: 4px;' bgcolor='#0a5c80'> <a target='_blank' style='text-decoration: underline; color: #fff; font-family: sans-serif; font-size: 17px; font-weight: 400; line-height: 120%;' href=" + callbackUrl + @"> Access your account </a> </td> </tr> </tbody> </table> </a> </td> </tr> <tr> <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; padding-top: 30px;' class='line'> <hr color='#565F73' align='center' width='100%' size='1' noshade='' style='margin: 0; padding: 0;'> </td> </tr> <tr> <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 13px; font-weight: 400; line-height: 150%; padding-top: 10px; padding-bottom: 20px; color: #828999; font-family: sans-serif;' class='footer'> You are receiving this email because of your relationship with POS Arqami . Please reconfirm your interest in receiving emails from us.If you do not wish to receive any more emails, you can unsubscribe here. <img width='1' height='1' border='0' vspace='0' hspace='0' style='margin: 0; padding: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: block;' src='https://raw.githubusercontent.com/konsav/email-templates/master/images/tracker.png'> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table> </body> </html>";

                var Subject = lang.Activare_your_account;

                //string url = $"{emailConfig.AppUrl}/api/auth/confirmemail?userid={identityUser.Id}&token={validEmailToken}";
                bool isMessageSent = mailService.SendEmailAsync(emailConfig.SmtpServer, emailConfig.Port, emailConfig.EnableSsl, emailConfig.From, identityUser.Email, Subject, Body, emailConfig.From, emailConfig.Password, emailConfig.UseDefaultCredentials);

                if (isMessageSent == false)
                {
                    var response = await DeletetUserAsync(User.Id);
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
            var user = await _userManger.FindByNameAsync(model.Username);
            if (user == null)
            {
                return new LoginResponseDto
                {
                    message = lang.The_username_or_password_is_incorrect,
                    success = false
                };

            }
            if (!user.EmailConfirmed)
            {
                return new LoginResponseDto
                {
                    message = lang.Your_account_is_not_activated_please_activate_it,
                    success = false
                };

            }
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var UserLockOut = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: true);

            if (UserLockOut.IsLockedOut)
            {
                //  var content =("Your account is locked out, to reset your password, please click this link:{forgotPassLink}" );
                return new LoginResponseDto
                {
                    message = lang.Your_account_is_locked_please_try_later,
                    success = false
                };
            }




            //if (user.LockoutEnabled == true)
            //{
            //    return new LoginResponseDto
            //    {
            //        message = lang.Your_account_is_locked_please_try_later,
            //        success = false
            //    };
            //}

            if (user.UserType != model.UserType)
            {
                return new LoginResponseDto
                {
                    message = lang.This_user_not_authorized_to_login,
                    success = false
                };
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

            if (user.CompanyId != null && user.RoleID != null)
            {
                Companies Company = null;
                Company = CompaniesService.GetCompany(user.CompanyId.Value);

                if (Company != null && Company.StatusId.Value == 6)
                {
                    return new LoginResponseDto
                    {
                        message = lang.Your_company_account_is_pending,
                        success = false
                    };

                }

                return new LoginResponseDto
                {
                    UserId = user.UserID,
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = tokenAsString,
                    message = "Login Successfully",
                    status = true,
                    companyId = user.CompanyId.ToString(),
                    Name = user.Name,
                    IsSuperAdmin=user.IsSuperAdmin,
                    CompanyNameEn = Company.CompanyName,
                    CompanyNameAr = Company.CompanyNameAr
                };


            }
            else if (user.CompanyId == null && user.UserType == 2)
            {
                return new LoginResponseDto
                {
                    UserId = user.UserID,
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = tokenAsString,
                    message = "Login Successfully",
                    IsSuperAdmin = user.IsSuperAdmin,
                    status = true,
                    Name = user.Name,
                };


            }

            return new LoginResponseDto
            {
                message = lang.An_error_occurred_while_processing_your_request,
                success = false,
            };

        }

        public async Task<bool> ConfirmEmailAsync(string userId, string code)
        {

            var User = await _userManger.FindByIdAsync(userId);
            var result = await _userManger.ConfirmEmailAsync(User, code);
            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async Task<UserManagerResponse> ForgetPasswordAsync(String Email, string Lang)
        {
            var user = await _userManger.FindByEmailAsync(Email);
            if (user == null)
            {
                return new UserManagerResponse
                {
                    message = lang.Invalid_email,
                    success = false
                };


            }
            else if (!(await _userManger.IsEmailConfirmedAsync(user)))
            {
                return new UserManagerResponse
                {
                    message = lang.Confirm_your_email,
                    success = false
                };

            }

            var Resetcode = await _userManger.GeneratePasswordResetTokenAsync(user);
            string AppUrl = emailConfig.AppUrl;
            if (user.UserType == 2)
            {
                AppUrl = emailConfig.AppUrlAdmin;
            }

            var callbackUrl = AppUrl + "?Resetcode=" + Resetcode + "&Lang=" + Lang;
            var Subject = lang.Reset_your_password;
            bool isMessageSent = false;
            string Body = "<html xmlns='http://www.w3.org/1999/xhtml'><head><meta http-equiv='content-type' content='text/html; charset=utf-8'>    <meta name='viewport' content='width=device-width, initial-scale=1.0;'>    <meta name='format-detection' content='telephone=no'>    <style>        body {            margin: 0;            padding: 0;            min-width: 100%;            width: 100% !important;            height: 100% !important;        }                body,        table,        td,        div,        p,        a {            -webkit-font-smoothing: antialiased;            text-size-adjust: 100%;            -ms-text-size-adjust: 100%;            -webkit-text-size-adjust: 100%;            line-height: 100%;        }                table,        td {            mso-table-lspace: 0pt;            mso-table-rspace: 0pt;            border-collapse: collapse !important;            border-spacing: 0;        }                img {            border: 0;            line-height: 100%;            outline: none;            text-decoration: none;            -ms-interpolation-mode: bicubic;        }                #outlook a {            padding: 0;        }                .ReadMsgBody {            width: 100%;        }                .ExternalClass {            width: 100%;        }                .ExternalClass,        .ExternalClass p,        .ExternalClass span,        .ExternalClass font,        .ExternalClass td,        .ExternalClass div {            line-height: 100%;        }                @media all and (min-width: 560px) {            .container {                border-radius: 8px;                -webkit-border-radius: 8px;                -moz-border-radius: 8px;                -khtml-border-radius: 8px;            }        }                a,        a:hover {            color: #0a5c80;        }                .footer a,        .footer a:hover {            color: #828999;        }    </style>    <title></title></head><body topmargin='0' rightmargin='0' bottommargin='0' leftmargin='0' marginwidth='0' marginheight='0' width='100%' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; width: 100%; height: 100%; -webkit-font-smoothing: antialiased; text-size-adjust: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; line-height: 100%;	background-color: #ffff;	color: #0a5c80;' bgcolor='#fff' text='##0a5c80'>    <table width='100%' align='center' border='0' cellpadding='0' cellspacing='0' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; width: 100%;' class='background'>        <tbody><tr>            <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0;' bgcolor='#fff'>                <table border='0' cellpadding='0' cellspacing='0' align='center' width='500' style='border-collapse: collapse; border-spacing: 0; padding: 0; width: inherit;	max-width: 500px;' class='wrapper'>                    <tbody><tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%;			padding-top: 20px;			padding-bottom: 20px;'>                            <div style='display: none; visibility: hidden; overflow: hidden; opacity: 0; font-size: 1px; line-height: 1px; height: 0; max-height: 0; max-width: 0;				color: #2D3445;' class='preheader'>                            </div>                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0;			padding-top: 0px;' class='hero'>                            <a target='_blank' style='text-decoration: none;' href='#'><img border='0' vspace='0' hspace='0' src='http://pos.opos.me/assets/images/arqami_logo.svg' alt='Please enable images to view this content' title='Hero Image' width='340' style='			width: 87.5%;			max-width: 340px;			color: #0a5c80; font-size: 13px; margin: 0; padding: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: block;'></a>                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 14px; font-weight: 400; line-height: 150%; letter-spacing: 2px;			padding-top: 27px;			padding-bottom: 0;			color: #0a5c80;			font-family: sans-serif;' class='supheader'>                            Welcome To                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0;  padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 24px; font-weight: bold; line-height: 130%;			padding-top: 5px;			color: #0a5c80;			font-family: sans-serif;' class='header'>                            POS Arqami System                        </td>                    </tr>                    <tr>                        <td align='right' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 17px; font-weight: 400; line-height: 160%;			padding-top: 15px; 			color: #0a5c80;			font-family: sans-serif;' class='paragraph'>                            Dear User , Welcome To POS Arqami System, Please click on the URL below to change your password.                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%;			padding-top: 25px;			padding-bottom: 5px;' class='button'>                            <a href=" + callbackUrl + @" target='_blank' style='text-decoration: underline;'>                                <table border='0' cellpadding='0' cellspacing='0' align='center' style='max-width: 240px; min-width: 120px; border-collapse: collapse; border-spacing: 0; padding: 0;'>                                    <tbody><tr>                                        <td align='center' valign='middle' style='padding: 12px 24px; margin: 0; text-decoration: underline; border-collapse: collapse; border-spacing: 0; border-radius: 4px; -webkit-border-radius: 4px; -moz-border-radius: 4px; -khtml-border-radius: 4px;' bgcolor='#0a5c80'><a target='_blank' style='text-decoration: underline;					color: #fff; font-family: sans-serif; font-size: 17px; font-weight: 400; line-height: 120%;' href=" + callbackUrl + @">                                                    Reset Password                                                </a>                                        </td>                                    </tr>                                </tbody></table>                            </a>                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%;			padding-top: 30px;' class='line'>                            <hr color='#565F73' align='center' width='100%' size='1' noshade='' style='margin: 0; padding: 0;'>                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 13px; font-weight: 400; line-height: 150%;			padding-top: 10px;			padding-bottom: 20px;			color: #828999;			font-family: sans-serif;' class='footer'>                            You are receiving this email because of your relationship with POS Arqami . Please reconfirm your interest in receiving emails from us.If you do not wish to receive any more emails, you can unsubscribe here.                            <img width='1' height='1' border='0' vspace='0' hspace='0' style='margin: 0; padding: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: block;' src='https://raw.githubusercontent.com/konsav/email-templates/master/images/tracker.png'>                        </td>                    </tr>                </tbody></table>            </td>        </tr>    </tbody></table></body></html>";
            isMessageSent = mailService.SendEmailAsync(emailConfig.SmtpServer, emailConfig.Port, false, emailConfig.From, Email, Subject, Body, emailConfig.From, emailConfig.Password, emailConfig.UseDefaultCredentials);

            if (isMessageSent == false)
            {
                return new UserManagerResponse
                {
                    success = false,
                    message = lang.Cant_send_forgot_password_email_please_try_later,
                };

            }
            else
            {
                return new UserManagerResponse
                {
                    success = true,
                    message = lang.Please_check_your_email_to_reset_your_password,
                };

            }

        }

        public string GetAllUsersAsync(int UserType, int? CompanyID)
        {
            return PosService.AuthRepository.GetAllUsersAsync(UserType, CompanyID);
        }

        public async Task<ApplicationUser> GetUserAsync(string Id)
        {
            var user = await _userManger.FindByIdAsync(Id);
            return user;
        }

        public async Task<UserManagerResponse> UpdateUserAsync(string Id, UserDto model)
        {
            var user = await _userManger.FindByIdAsync(Id);
            var result = await _userManger.UpdateAsync(user);
            //user.FirstName = model.FirstName;
            user.Email = model.Email;
            user.UserName = model.UserName;
            //return null;
            if (result.Succeeded)
            {
                return new UserManagerResponse
                {
                    message = lang.Updated_successfully_completed,
                    success = true,
                };
            }
            return new UserManagerResponse
            {
                message = lang.An_error_occurred_while_processing_your_request,
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

                message = lang.An_error_occurred_while_processing_your_request,
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

                if (await _userManger.IsLockedOutAsync(user))
                {
                    await _userManger.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow);
                }
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

        public async Task<UserManagerResponse> ChangePassword(string UserID, string OldPassword, string NewPassword)
        {
            ApplicationUser user = await _userManger.FindByIdAsync(UserID);
            var result = await _userManger.ChangePasswordAsync(user, OldPassword, NewPassword);
            if (!result.Succeeded)
            {

                foreach (var error in result.Errors)
                {
                    if (error.Description == "Incorrect password.")
                    {
                        return new UserManagerResponse { message = lang.Incorrect_current_password, success = false };
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
                success = true,
            };
        }

        public async Task<ApplicationUser> IdentityApplicationUser(string userName)
        {
            var user = await _userManger.FindByIdAsync(userName);
            return user;
        }

        public async Task<UserManagerResponse> AddUserAsync(UserModel model)
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

            var identityUser = new ApplicationUser()
            {
                UserName = model.Username,
                Email = model.Email,
                CreateDate = DateTime.Now,
                InsertedBy = model.UesrID,
                Name = model.Name,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                EmailConfirmed = true,
                IsSuperAdmin = model.IsSuperAdmin,
                LockoutEnabled = true,
                CompanyId = model.CompanyId,
                UserType = model.UserType,

                // VerificationCode = VerificationCode
            };
            var result = await _userManger.CreateAsync(identityUser, model.Password);
            if (result.Succeeded)
            {

                return new UserManagerResponse
                {
                    message = lang.Saved_successfully_completed,
                    success = true,
                };
            }

            return new UserManagerResponse
            {
                message = lang.An_error_occurred_while_processing_your_request,
                success = false,
            };

        }

        public async Task<UserManagerResponse> UpdateUserAsync(UserModel model)
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

            var appUser = await _userManger.FindByEmailAsync(model.Id);

            if (appUser != null && (appUser.Email == model.Email && appUser.Id != model.Id))
            {
                return new UserManagerResponse
                {
                    message = lang.Either_username_and_or_email_already_exists,
                    success = false,
                };
            }

            appUser = await _userManger.FindByNameAsync(model.Username);
            if (appUser != null && (appUser.UserName == model.Username && appUser.Id != model.Id))
            {
                return new UserManagerResponse
                {
                    message = lang.Either_username_and_or_email_already_exists,
                    success = false,
                };

            }
            var User = await _userManger.FindByIdAsync(model.Id);

            User.UserName = model.Username;
            User.Email = model.Email;
            User.LastModifyDate = DateTime.Now;
            User.ModifiedBy = model.UesrID;
            User.Name = model.Name;
            User.Password = model.Password;
            User.PhoneNumber = model.PhoneNumber;
            User.EmailConfirmed = true;
            User.IsSuperAdmin = model.IsSuperAdmin;
            User.LockoutEnabled = true;
            User.CompanyId = model.CompanyId;
            User.UserType = model.UserType;
            User.RoleID = model.RoleID;
            var result = await _userManger.CreateAsync(User, model.Password);
            if (result.Succeeded)
            {

                return new UserManagerResponse
                {
                    message = lang.Saved_successfully_completed,
                    success = true,
                };
            }


            return new UserManagerResponse
            {
                message = lang.An_error_occurred_while_processing_your_request,
                success = false,
            };

        }

        public async Task<UserManagerResponse> CreateUserAsync(CreateUserModel model)
        {
            try
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


                var identityUser = new ApplicationUser()
                {
                    UserName = model.Username,
                    Email = model.Email,
                    CreateDate = DateTime.Now,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    InsertedBy = model.InsertedBy,
                    UserType = model.UserType,
                    EmailConfirmed = true,
                    IsSuperAdmin = model.IsSuperAdmin,
                    LockoutEnabled = true,
                    CompanyId = model.CompanyId
                };

                string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
                Random random = new Random();
                string Password = "";
                for (int i = 0; i < 6; i++)
                {
                    Password += validChars[random.Next(0, validChars.Length)];
                }
                identityUser.Password = Password.ToString();
                var result = await _userManger.CreateAsync(identityUser, Password.ToString());


                if (result.Succeeded)
                {
                    var confirmEmailToken = await _userManger.GenerateEmailConfirmationTokenAsync(identityUser);

                    var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
                    var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);

                    var User = await _userManger.FindByEmailAsync(model.Email);

                    string code = await this._userManger.GenerateEmailConfirmationTokenAsync(User);
                    var callbackUrl = model.AppUrl + "?userId=" + User.Id + "&code=" + code + "&lang=" + model.Lang;


                    //var Body = lang.Please_activate_your_account_by_clicking + "<a href=\"" + callbackUrl + "\"> " + lang.Here + "</a>";
                    string Body = "<html xmlns='http://www.w3.org/1999/xhtml'><head>    <meta http-equiv='content-type' content='text/html; charset=utf-8'>    <meta name='viewport' content='width=device-width, initial-scale=1.0;'>    <meta name='format-detection' content='telephone=no' />    <style>        body {            margin: 0;            padding: 0;            min-width: 100%;            width: 100% !important;            height: 100% !important;        }                body,        table,        td,        div,        p,        a {            -webkit-font-smoothing: antialiased;            text-size-adjust: 100%;            -ms-text-size-adjust: 100%;            -webkit-text-size-adjust: 100%;            line-height: 100%;        }                table,        td {            mso-table-lspace: 0pt;            mso-table-rspace: 0pt;            border-collapse: collapse !important;            border-spacing: 0;        }                img {            border: 0;            line-height: 100%;            outline: none;            text-decoration: none;            -ms-interpolation-mode: bicubic;        }                #outlook a {            padding: 0;        }                .ReadMsgBody {            width: 100%;        }                .ExternalClass {            width: 100%;        }                .ExternalClass,        .ExternalClass p,        .ExternalClass span,        .ExternalClass font,        .ExternalClass td,        .ExternalClass div {            line-height: 100%;        }                @media all and (min-width: 560px) {            .container {                border-radius: 8px;                -webkit-border-radius: 8px;                -moz-border-radius: 8px;                -khtml-border-radius: 8px;            }        }                a,        a:hover {            color: #0a5c80;        }                .footer a,        .footer a:hover {            color: #828999;        }    </style>    <title></title></head><body topmargin='0' rightmargin='0' bottommargin='0' leftmargin='0' marginwidth='0' marginheight='0' width='100%' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; width: 100%; height: 100%; -webkit-font-smoothing: antialiased; text-size-adjust: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; line-height: 100%;	background-color: #ffff;	color: #0a5c80;' bgcolor='#fff' text='##0a5c80'>    <table width='100%' align='center' border='0' cellpadding='0' cellspacing='0' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; width: 100%;' class='background'>        <tr>            <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0;' bgcolor='#fff'>                <table border='0' cellpadding='0' cellspacing='0' align='center' width='500' style='border-collapse: collapse; border-spacing: 0; padding: 0; width: inherit;	max-width: 500px;' class='wrapper'>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%;			padding-top: 20px;			padding-bottom: 20px;'>                            <div style='display: none; visibility: hidden; overflow: hidden; opacity: 0; font-size: 1px; line-height: 1px; height: 0; max-height: 0; max-width: 0;				color: #2D3445;' class='preheader'>                            </div>                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0;			padding-top: 0px;' class='hero'>                            <a target='_blank' style='text-decoration: none;' href='#'><img border='0' vspace='0' hspace='0' src='http://pos.opos.me/assets/images/arqami_logo.svg' alt='Please enable images to view this content' title='Hero Image' width='340' style='			width: 87.5%;			max-width: 340px;			color: #0a5c80; font-size: 13px; margin: 0; padding: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: block;' /></a>                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 14px; font-weight: 400; line-height: 150%; letter-spacing: 2px;			padding-top: 27px;			padding-bottom: 0;			color: #0a5c80;			font-family: sans-serif;' class='supheader'>                            Welcome To                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0;  padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 24px; font-weight: bold; line-height: 130%;			padding-top: 5px;			color: #0a5c80;			font-family: sans-serif;' class='header'>                            POS Arqami System                        </td>                    </tr>                    <tr>                        <td align='right' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 17px; font-weight: 400; line-height: 160%;			padding-top: 15px; 			color: #0a5c80;            font-family: sans-serif; text-align: center;' class='paragraph'>Dear Client, your Password is:                            <b class='text-center'></b>                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%;			padding-top: 25px;			padding-bottom: 5px;' class='button'>                            <a target='_blank' style='text-decoration: underline;'>                                <table border='0' cellpadding='0' cellspacing='0' align='center' style='max-width: 400px; min-width: 120px; border-collapse: collapse; border-spacing: 0; padding: 0;'>                                    <tr>                                        <td  align='center' valign='middle' style='padding: 12px 24px;color: white;font-weight: bold;                                        margin: 0;  border-collapse: collapse; border-spacing: 0; border-radius: 4px; -webkit-border-radius: 4px; -moz-border-radius: 4px; -khtml-border-radius: 4px;' bgcolor='#0a5c80'>                                            " + Password + "                                        </td>                                    </tr>                                </table>                            </a>                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%;			padding-top: 30px;' class='line'>                            <hr color='#565F73' align='center' width='100%' size='1' noshade style='margin: 0; padding: 0;' />                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 13px; font-weight: 400; line-height: 150%;			padding-top: 10px;			padding-bottom: 20px;			color: #828999;			font-family: sans-serif;' class='footer'>                            You are receiving this email because of your relationship with POS Arqami . Please reconfirm your interest in receiving emails from us.If you do not wish to receive any more emails, you can unsubscribe here.                            <img width='1' height='1' border='0' vspace='0' hspace='0' style='margin: 0; padding: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: block;' src='https://raw.githubusercontent.com/konsav/email-templates/master/images/tracker.png'                            />                        </td>                    </tr>                </table>            </td>        </tr>    </table></body></html>";

                    var Subject = lang.Your_registration_completed_successfully;

                    //string url = $"{emailConfig.AppUrl}/api/auth/confirmemail?userid={identityUser.Id}&token={validEmailToken}";
                    bool isMessageSent = mailService.SendEmailAsync(emailConfig.SmtpServer, emailConfig.Port, emailConfig.EnableSsl, emailConfig.From, identityUser.Email, Subject, Body, emailConfig.From, emailConfig.Password, emailConfig.UseDefaultCredentials);

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

            }
            catch (Exception ex)
            {
                ExceptionError(ex);
            }
            return new UserManagerResponse
            {
                message = lang.An_error_occurred_while_processing_your_request,
                success = false,
            };

        }

        public async Task<UserManagerResponse> SaveUser(CreateUserModel model)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(model.Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(model.Lang);

                if (model.Id == "0" || model.Id == null)
                {

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


                    var identityUser = new ApplicationUser()
                    {
                        UserName = model.Username,
                        Email = model.Email,
                        CreateDate = DateTime.Now,
                        Name = model.Name,
                        PhoneNumber = model.PhoneNumber,
                        InsertedBy = model.InsertedBy,
                        UserType = model.UserType,
                        EmailConfirmed = true,
                        IsSuperAdmin = model.IsSuperAdmin,
                        LockoutEnabled = true,
                        CompanyId = model.CompanyId,
                        StatusID = model.StatusID,
                        RoleID = model.RoleID,



                    };
                    if (identityUser.IsSuperAdmin == true)
                    {
                        identityUser.RoleID = null;
                    }

                    string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
                    Random random = new Random();
                    string Password = "";
                    for (int i = 0; i < 6; i++)
                    {
                        Password += validChars[random.Next(0, validChars.Length)];
                    }
                    identityUser.Password = Password.ToString();
                    var result = await _userManger.CreateAsync(identityUser, Password.ToString());


                    if (result.Succeeded)
                    {
                        var confirmEmailToken = await _userManger.GenerateEmailConfirmationTokenAsync(identityUser);

                        var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
                        var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);

                        var User = await _userManger.FindByEmailAsync(model.Email);

                        string code = await this._userManger.GenerateEmailConfirmationTokenAsync(User);
                        var callbackUrl = model.AppUrl + "?userId=" + User.Id + "&code=" + code + "&lang=" + model.Lang;


                        //var Body = lang.Please_activate_your_account_by_clicking + "<a href=\"" + callbackUrl + "\"> " + lang.Here + "</a>";
                        string Body = "<html xmlns='http://www.w3.org/1999/xhtml'><head>    <meta http-equiv='content-type' content='text/html; charset=utf-8'>    <meta name='viewport' content='width=device-width, initial-scale=1.0;'>    <meta name='format-detection' content='telephone=no' />    <style>        body {            margin: 0;            padding: 0;            min-width: 100%;            width: 100% !important;            height: 100% !important;        }                body,        table,        td,        div,        p,        a {            -webkit-font-smoothing: antialiased;            text-size-adjust: 100%;            -ms-text-size-adjust: 100%;            -webkit-text-size-adjust: 100%;            line-height: 100%;        }                table,        td {            mso-table-lspace: 0pt;            mso-table-rspace: 0pt;            border-collapse: collapse !important;            border-spacing: 0;        }                img {            border: 0;            line-height: 100%;            outline: none;            text-decoration: none;            -ms-interpolation-mode: bicubic;        }                #outlook a {            padding: 0;        }                .ReadMsgBody {            width: 100%;        }                .ExternalClass {            width: 100%;        }                .ExternalClass,        .ExternalClass p,        .ExternalClass span,        .ExternalClass font,        .ExternalClass td,        .ExternalClass div {            line-height: 100%;        }                @media all and (min-width: 560px) {            .container {                border-radius: 8px;                -webkit-border-radius: 8px;                -moz-border-radius: 8px;                -khtml-border-radius: 8px;            }        }                a,        a:hover {            color: #0a5c80;        }                .footer a,        .footer a:hover {            color: #828999;        }    </style>    <title></title></head><body topmargin='0' rightmargin='0' bottommargin='0' leftmargin='0' marginwidth='0' marginheight='0' width='100%' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; width: 100%; height: 100%; -webkit-font-smoothing: antialiased; text-size-adjust: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; line-height: 100%;	background-color: #ffff;	color: #0a5c80;' bgcolor='#fff' text='##0a5c80'>    <table width='100%' align='center' border='0' cellpadding='0' cellspacing='0' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; width: 100%;' class='background'>        <tr>            <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0;' bgcolor='#fff'>                <table border='0' cellpadding='0' cellspacing='0' align='center' width='500' style='border-collapse: collapse; border-spacing: 0; padding: 0; width: inherit;	max-width: 500px;' class='wrapper'>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%;			padding-top: 20px;			padding-bottom: 20px;'>                            <div style='display: none; visibility: hidden; overflow: hidden; opacity: 0; font-size: 1px; line-height: 1px; height: 0; max-height: 0; max-width: 0;				color: #2D3445;' class='preheader'>                            </div>                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0;			padding-top: 0px;' class='hero'>                            <a target='_blank' style='text-decoration: none;' href='#'><img border='0' vspace='0' hspace='0' src='http://pos.opos.me/assets/images/arqami_logo.svg' alt='Please enable images to view this content' title='Hero Image' width='340' style='			width: 87.5%;			max-width: 340px;			color: #0a5c80; font-size: 13px; margin: 0; padding: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: block;' /></a>                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 14px; font-weight: 400; line-height: 150%; letter-spacing: 2px;			padding-top: 27px;			padding-bottom: 0;			color: #0a5c80;			font-family: sans-serif;' class='supheader'>                            Welcome To                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0;  padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 24px; font-weight: bold; line-height: 130%;			padding-top: 5px;			color: #0a5c80;			font-family: sans-serif;' class='header'>                            POS Arqami System                        </td>                    </tr>                    <tr>                        <td align='right' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 17px; font-weight: 400; line-height: 160%;			padding-top: 15px; 			color: #0a5c80;            font-family: sans-serif; text-align: center;' class='paragraph'>Dear Client, your Password is:                            <b class='text-center'></b>                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%;			padding-top: 25px;			padding-bottom: 5px;' class='button'>                            <a target='_blank' style='text-decoration: underline;'>                                <table border='0' cellpadding='0' cellspacing='0' align='center' style='max-width: 400px; min-width: 120px; border-collapse: collapse; border-spacing: 0; padding: 0;'>                                    <tr>                                        <td  align='center' valign='middle' style='padding: 12px 24px;color: white;font-weight: bold;                                        margin: 0;  border-collapse: collapse; border-spacing: 0; border-radius: 4px; -webkit-border-radius: 4px; -moz-border-radius: 4px; -khtml-border-radius: 4px;' bgcolor='#0a5c80'>                                            " + Password + "                                        </td>                                    </tr>                                </table>                            </a>                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%;			padding-top: 30px;' class='line'>                            <hr color='#565F73' align='center' width='100%' size='1' noshade style='margin: 0; padding: 0;' />                        </td>                    </tr>                    <tr>                        <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 13px; font-weight: 400; line-height: 150%;			padding-top: 10px;			padding-bottom: 20px;			color: #828999;			font-family: sans-serif;' class='footer'>                            You are receiving this email because of your relationship with POS Arqami . Please reconfirm your interest in receiving emails from us.If you do not wish to receive any more emails, you can unsubscribe here.                            <img width='1' height='1' border='0' vspace='0' hspace='0' style='margin: 0; padding: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: block;' src='https://raw.githubusercontent.com/konsav/email-templates/master/images/tracker.png'                            />                        </td>                    </tr>                </table>            </td>        </tr>    </table></body></html>";

                        var Subject = lang.Your_registration_completed_successfully;

                        //string url = $"{emailConfig.AppUrl}/api/auth/confirmemail?userid={identityUser.Id}&token={validEmailToken}";
                        bool isMessageSent = mailService.SendEmailAsync(emailConfig.SmtpServer, emailConfig.Port, emailConfig.EnableSsl, emailConfig.From, identityUser.Email, Subject, Body, emailConfig.From, emailConfig.Password, emailConfig.UseDefaultCredentials);

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
                            message = lang.Your_registration_completed_successfully + ", " + lang.The_password_has_been_sent_to_the_e_mail,
                            //EmailConfirmed = User.EmailConfirmed,
                            success = true,
                        };
                    }

                }
                else
                {

                    var appUser = await _userManger.FindByIdAsync(model.Id);
                    appUser.Email = model.Email;
                    appUser.UserName = model.Email;
                    appUser.Name = model.Name;
                    appUser.PhoneNumber = model.PhoneNumber;
                    appUser.LastModifyDate = DateTime.Now;
                    appUser.UserType = model.UserType;
                    appUser.CompanyId = model.CompanyId;
                    appUser.InsertedBy = model.InsertedBy;
                    appUser.ModifiedBy = model.ModifiedBy;
                    appUser.IsSuperAdmin = model.IsSuperAdmin;
                    appUser.StatusID = model.StatusID;
                    appUser.RoleID = model.RoleID;
                    if (appUser.IsSuperAdmin == true)
                    {
                        appUser.RoleID = null;
                    }
                    var result = await _userManger.UpdateAsync(appUser);

                    if (result.Succeeded)
                    {

                        return new UserManagerResponse
                        {
                            message = lang.Updated_successfully_completed,
                            success = true,
                        };

                    }
                }
            }


            catch (Exception ex)
            {
                ExceptionError(ex);
            }
            return new UserManagerResponse
            {
                message = lang.An_error_occurred_while_processing_your_request,
                success = false,
            };

        }


    }

}
