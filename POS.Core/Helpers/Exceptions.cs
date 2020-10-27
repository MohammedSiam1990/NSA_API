using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using EmailService;
namespace Exceptions
{
    public class ExceptionError
    {
        
        public static void SaveException(Exception ex, EmailConfiguration EmailSetting)
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
                SendEmailAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public bool SendEmailAsync(string Smtp, int Port, bool EnableSsl, string From, string To, string Subject, string body, string CredentialEmail, string CredentialPassword, bool UseDefaultCredentials)
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
            catch //(SmtpException ex)
            {
                //ExceptionError.SaveException(ex);

            }
            return false;
        }
    }
}