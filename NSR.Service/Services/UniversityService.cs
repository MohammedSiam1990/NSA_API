using NSR.Entities;
using NSR.IService.Base;
using NSR.Service.IService;
using System.Collections.Generic;



using EmailService;
using Microsoft.AspNetCore.Identity;
using NSR.Core.Resources;
using Steander.Core.Entities; 
namespace NSR.Service.Services
{
    public class UniversityService : BaseService, IUniversityService
    {
        private UserManager<ApplicationUser> _userManger;
        EmailConfiguration emailConfig;
        private IMailService mailService; 
        public UniversityService(UserManager<ApplicationUser> userManager,
             EmailConfiguration _emailConfig, 
          IMailService _mailService)
        {
            _userManger = userManager;
            emailConfig = _emailConfig; 
            mailService = _mailService;
        }

        public void AddUniversity(University University)
        {
            PosService.UniversityRepository.AddUniversity(University);
        }

        public void DeleteUniversity(int UniversityId)
        {
            PosService.UniversityRepository.DeleteUniversity(UniversityId);
        }

        public List<University> GetUniversitys()
        {
            return PosService.UniversityRepository.GetUniversitys();
        }
     
        public University GetUniversity(int InsertedBy)
        {
            return PosService.UniversityRepository.GetUniversity(InsertedBy);
        }


        public University GetUniversityID(int UniversityID)
        {
            return PosService.UniversityRepository.GetUniversityID(UniversityID);

        }
        public int SaveUniversity(University University,string Img)
        {
            
            //var Body = lang.Please_activate_your_account_by_clicking + "<a href=\"" + callbackUrl + "\"> " + lang.Here + "</a>";
            var Body = "<html xmlns='http://www.w3.org/1999/xhtml'><head> <meta http-equiv='content-type' content='text/html; charset=utf-8'> <meta name='viewport' content='width=device-width, initial-scale=1.0;'> <meta name='format-detection' content='telephone=no'> <style> body {  margin: 0;  padding: 0;  min-width: 100%;  width: 100% !important;  height: 100% !important; } body, table, td, div, p, a {  -webkit-font-smoothing: antialiased;  text-size-adjust: 100%;  -ms-text-size-adjust: 100%;  -webkit-text-size-adjust: 100%;  line-height: 100%; } table, td {  mso-table-lspace: 0pt;  mso-table-rspace: 0pt;  border-collapse: collapse !important;  border-spacing: 0; } img {  border: 0;  line-height: 100%;  outline: none;  text-decoration: none;  -ms-interpolation-mode: bicubic; } #outlook a {  padding: 0; } .ReadMsgBody {  width: 100%; } .ExternalClass {  width: 100%; } .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {  line-height: 100%; } @media all and (min-width: 560px) {  .container {  border-radius: 8px;  -webkit-border-radius: 8px;  -moz-border-radius: 8px;  -khtml-border-radius: 8px;  } } a, a:hover {  color: #0a5c80; } .footer a, .footer a:hover {  color: #828999; } </style> <title></title></head><body topmargin='0' rightmargin='0' bottommargin='0' leftmargin='0' marginwidth='0' marginheight='0' width='100%' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; width: 100%; height: 100%; -webkit-font-smoothing: antialiased; text-size-adjust: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; line-height: 100%; background-color: #ffff; color: #0a5c80;' bgcolor='#fff' text='##0a5c80'> <table width='100%' align='center' border='0' cellpadding='0' cellspacing='0' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; width: 100%;' class='background'> <tbody>  <tr>  <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0;' bgcolor='#fff'>   <table border='0' cellpadding='0' cellspacing='0' align='center' width='500' style='border-collapse: collapse; border-spacing: 0; padding: 0; width: inherit; max-width: 500px;' class='wrapper'>   <tbody> <tr> <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; padding-top: 20px; padding-bottom: 20px;'>     <div style='display: none; visibility: hidden; overflow: hidden; opacity: 0; font-size: 1px; line-height: 1px; height: 0; max-height: 0; max-width: 0; color: #2D3445;' class='preheader'> </div>    </td>    </tr>    <tr>    <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-top: 0px;' class='hero'> <a target='_blank' style='text-decoration: none;' href='#'> <img border='0' vspace='0' hspace='0' src=" + Img + @" alt='Please enable images to view this content' title='Hero Image' width='400' style=' width: 87.5%; max-width: 400px; color: #0a5c80; font-size: 13px; margin: 0; padding: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: block;'> </a>     </td>    </tr>    <tr>    <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 14px; font-weight: 400; line-height: 150%; letter-spacing: 2px; padding-top: 27px; padding-bottom: 0; color: #0a5c80; font-family: sans-serif;'     class='supheader'> Welcome To </td>    </tr>    <tr>    <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 24px; font-weight: bold; line-height: 130%; padding-top: 5px; color: #0a5c80; font-family: sans-serif;'     class='header'> National Service Registration </td>    </tr>    <tr>    <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 17px; font-weight: 400; line-height: 160%; padding-top: 15px; color: #0a5c80; font-family: sans-serif;'     class='paragraph'> Dear User , Welcome To National Service Registration, your account has been created with login information below </td>    </tr><tr>    <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; padding-top: 30px;' class='line'>     <hr color='#565F73' align='center' width='100%' size='1' noshade='' style='margin: 0; padding: 0;'> </td>    </tr>    <tr>    <td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 13px; font-weight: 400; line-height: 150%; padding-top: 10px; padding-bottom: 20px; color: #828999; font-family: sans-serif;'     class='footer'> You are receiving this email because of your relationship with National Service Registration . Please reconfirm your interest in receiving emails from us. If you do not wish to receive any more emails, you can unsubscribe here.     </td>    </tr>   </tbody>   </table>  </td>  </tr> </tbody> </table></body></html>";

            var Subject = lang.Activare_your_account;

            //string url = $"{emailConfig.AppUrl}/api/auth/confirmemail?userid={identityUser.Id}&token={validEmailToken}";
            
            var result = PosService.UniversityRepository.SaveUniversity(University, Img);
            if (result == 1)
            {
                bool isMessageSent = mailService.SendEmailAsync(emailConfig.SmtpServer, emailConfig.Port, emailConfig.EnableSsl, emailConfig.From, "muathwww@hotmail.com",
                Subject, Body, emailConfig.From, emailConfig.Password, emailConfig.UseDefaultCredentials);
            }
            return result;
        }

        public void UpdateUniversity(University University)
        {
            PosService.UniversityRepository.UpdateUniversity(University);
        }

        public University ValidateAlreadyExist(University model)
        {
            return PosService.UniversityRepository.ValidateAlreadyExist(model);
        }


        public string GetProUniversitysAll()
        {
            return PosService.UniversityRepository.GetProUniversitysAll();
        }
    }
}
