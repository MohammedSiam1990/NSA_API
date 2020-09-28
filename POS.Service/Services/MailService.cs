using Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace POS.Service.Services
{
    public class MailService : IMailService
    {
        private IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        public bool SendEmailAsync(string Smtp, int Port, bool EnableSsl, string From, string To, string Subject, string body, string CredentialEmail, string CredentialPassword,bool UseDefaultCredentials)
        {
            try
            {
                MailAddress to = new MailAddress(To);
                MailAddress from = new MailAddress(From);

                MailMessage message = new MailMessage(from, to);
                message.Subject = Subject;
                message.Body = body;
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient
                {
                    Host = Smtp,//"smtp.gmail.com",
                    Port = Port,
                    EnableSsl = EnableSsl
                };

                client.UseDefaultCredentials = UseDefaultCredentials;
                client.Credentials = new NetworkCredential(CredentialEmail, CredentialPassword);
                client.Send(message);
                return true;
            }
            catch (SmtpException ex)
            {
                ExceptionError.SaveException(ex);
                
            }
            return false;
        }

        //public Task SendEmailAsync(string From, string To, string Subject, string body, string CredentialEmail, string CredentialPasswordt)
        //{
        //    throw new NotImplementedException();
        //}
    }
}