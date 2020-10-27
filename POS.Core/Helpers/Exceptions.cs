using EmailService;
using System;
using System.IO;

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
                ;
                HelperEmail.SendEmail("","","");
                System.IO.File.WriteAllText(file_name, System.IO.File.ReadAllText(file_name) + DateTime.Now + Environment.NewLine + ex.Message + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + Environment.NewLine);
                //bool isMessageSent = mailService.SendEmailAsync(emailConfig.SmtpServer, emailConfig.Port, emailConfig.EnableSsl, emailConfig.From, identityUser.Email, Subject, Body, emailConfig.From, emailConfig.Password, emailConfig.UseDefaultCredentials);

            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}