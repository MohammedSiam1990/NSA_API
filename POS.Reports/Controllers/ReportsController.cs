using System.Web;
using Telerik.Reporting.Services;
using Telerik.Reporting.Services.WebApi;

public class ReportsController : ReportsControllerBase
{
    static readonly ReportServiceConfiguration configurationInstance =
        new ReportServiceConfiguration
        {
            HostAppId = "POS.API",
            ReportSourceResolver = new UriReportSourceResolver(HttpContext.Current.Server.MapPath("~/Reports"))
                .AddFallbackResolver(new TypeReportSourceResolver()),
            Storage = new Telerik.Reporting.Cache.File.FileStorage(),
        };

    public ReportsController()
    {
        this.ReportServiceConfiguration = configurationInstance;
    }

    // protected override HttpStatusCode SendMailMessage(MailMessage mailMessage)
    //{
    //    using (var smtpClient = new SmtpClient("smtp.companyname.com", 25))
    //    {
    //        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
    //        smtpClient.EnableSsl = true;
    //        smtpClient.Send(mailMessage);
    //    }

    //    return HttpStatusCode.OK;
    //}
}