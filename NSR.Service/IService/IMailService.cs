public interface IMailService
{
    bool SendEmailAsync(string Smtp, int Port, bool EnableSsl, string From, string To, string Subject, string body, string CredentialEmail, string CredentialPasswordt, bool UseDefaultCredentials);
}