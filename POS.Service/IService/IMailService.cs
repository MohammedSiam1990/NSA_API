using System.Threading.Tasks;

public interface IMailService
{

    Task SendEmailAsync(string Smtp, int Port, bool EnableSsl,string From, string To, string Subject, string body, string CredentialEmail, string CredentialPasswordt);
}