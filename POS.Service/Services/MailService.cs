using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Services
{
    public class MailService : IMailService
    {
        private IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        public bool  SendEmailAsync(string Smtp, int Port, bool EnableSsl, string From, string To, string Subject, string body, string CredentialEmail, string CredentialPassword)
        {
            MailAddress to = new MailAddress(To);
            MailAddress from = new MailAddress(From);

            MailMessage message = new MailMessage(from, to);
            message.Subject = Subject;
            message.Body = body;

            SmtpClient client = new SmtpClient
            {
                Host = Smtp,//"smtp.gmail.com",
                Port = Port,
                EnableSsl = EnableSsl
            };
            try
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(CredentialEmail, CredentialPassword);
                client.Send(message);
                return true;
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
               return false;
            }
        }

        //public Task SendEmailAsync(string From, string To, string Subject, string body, string CredentialEmail, string CredentialPasswordt)
        //{
        //    throw new NotImplementedException();
        //}
    }
}