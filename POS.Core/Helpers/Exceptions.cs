using EmailService;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
namespace Exceptions
{
    public class ExceptionError
    {
        public static void SaveException(Exception ex)
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
                var ErrorText = DateTime.Now + Environment.NewLine + ex.Message + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source
                    + Environment.NewLine + Environment.NewLine + ex.InnerException.Message ;
                System.IO.File.WriteAllText(file_name, System.IO.File.ReadAllText(file_name) + ErrorText);

                // Send Mail Exception
                var Appsettings = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                var jsonAppsettings = File.ReadAllText(Appsettings);
                var jsonEmailconfig = JObject.Parse(jsonAppsettings);
                var emailConfig = JsonConvert.DeserializeObject<EmailConfiguration>(jsonEmailconfig["EmailConfiguration"].ToString());
                var Emails = emailConfig.ExceptionErrorEmail.Split(',');
                var Subject = "Exception Mail from Company";
                var Body = ErrorText;
                foreach (var email in Emails)
                {
                    SendEmailAsync(emailConfig.SmtpServer,
                    emailConfig.Port,
                    emailConfig.EnableSsl,
                    emailConfig.From,
                    email,
                    Subject,
                    Body,
                    emailConfig.From,
                    emailConfig.Password,
                    emailConfig.UseDefaultCredentials
                       );

                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public static bool SendEmailAsync(string Smtp, int Port, bool EnableSsl, string From, string To, string Subject, string body, string CredentialEmail, string CredentialPassword, bool UseDefaultCredentials)
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