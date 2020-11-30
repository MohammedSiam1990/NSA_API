namespace POS.API.Controllers
{
    using System.Net;
    using System.Net.Mail;
    using Microsoft.AspNetCore.Mvc;
    using Telerik.Reporting.Services;
    using Telerik.Reporting.Services.AspNetCore;

    [Route("api/reports")]
    public class ReportsController : ReportsControllerBase
    {
        public ReportsController(IReportServiceConfiguration reportServiceConfiguration)
            : base(reportServiceConfiguration)
        {
        }

        //protected override HttpStatusCode SendMailMessage(MailMessage mailMessage)
        //{
        //}
    }
}
