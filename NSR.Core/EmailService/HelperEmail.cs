
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace EmailService
{
    [Serializable]
    public static class HelperEmail
    {
        public static bool SendMail(string SmtpServer, string From, int Port, string To, string Subject, string Body, string CredentialEmail, string Password,bool EnableSsl = true)
        {
            MailMessage mail = new MailMessage(From, To);
            SmtpClient smtpclient = new SmtpClient();
            smtpclient.Port = Port;//"587"
            smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
           // smtpclient.UseDefaultCredentials = false;
            smtpclient.Host = SmtpServer; //"smtp.gmail.com";
            mail.Subject = Subject;
            mail.Body = Body;
            smtpclient.EnableSsl = EnableSsl;
            smtpclient.UseDefaultCredentials =true;
            smtpclient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = CredentialEmail,
                Password = Password
            };
            smtpclient.Send(mail);
            return true;
        }

        public static bool SendMail2(string SmtpServer, string From, int Port, string To, string Subject, string Body, string CredentialEmail, string Password, bool EnableSsl = true)
        {

            MailAddress to = new MailAddress(To);
            MailAddress from = new MailAddress(From);

            MailMessage message = new MailMessage(from, to);
            message.Subject = Subject;
            message.Body = Body;

            SmtpClient client = new SmtpClient
            {
                Host = "smtp.arqami.net",
                Port = 25,
                EnableSsl = false
            };
           
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(CredentialEmail, Password);
                client.Send(message);
            return true;
        }



        public static bool SendEmail(string recipient, string subject, string message)
        {
            bool isMessageSent = false;

            // Emails will be sent from this address
            var from = "webmail@arqami.net";//"ehab@arqami.net";
                var pass = "dDUGKVl4";
                // Setting up SMTP client
                SmtpClient client = new SmtpClient();
                NetworkCredential basicCredential = new NetworkCredential(from, pass);

                client.Host = "smtp.arqami.net";
                client.Port = 25;
                client.UseDefaultCredentials = true;
                client.Credentials = basicCredential;
                //     client.EnableSsl = true;
                // Create email

                MailMessage mail = new MailMessage();
                MailAddress fromAddress = new MailAddress(from);
                mail.From = fromAddress;
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;


                if (recipient.ToLower().Contains(","))
                {
                    string[] emails = recipient.Split(',');
                    foreach (string email in emails)
                    {
                        mail.To.Add(email);
                    }
                }
                else
                {
                    mail.To.Add(recipient);
                }
                // Send email
               client.Send(mail);
                isMessageSent = true;

                return isMessageSent;
            }
           
       

    }
}