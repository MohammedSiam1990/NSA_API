using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Reports.Reports;
using Telerik.Reporting;
using Telerik.Reporting.Cache.File;
using Telerik.Reporting.Services;
using Telerik.Reporting.Services.AspNetCore;
using Telerik.Reporting.Services.Engine;

namespace POS.API.Controllers
{
    [Obsolete]
    public class MyResolver : IReportResolver
    {
        public ReportSource Resolve(string reportId)
        {
            // Creating a new report book
            var reportBook = new Report1();

            //Add first report
            var firstReportSource = new TypeReportSource();
            firstReportSource.TypeName = typeof(Report1).AssemblyQualifiedName;
            reportBook.Report.DataSource.ToString();
            var result = new InstanceReportSource { ReportDocument = reportBook };

            return result;
        }
    }

    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class ReportsController : ReportsControllerBase
    {
        [Obsolete]
        public ReportsController()
        {
            IReportServiceConfiguration reportServiceConfiguration = new ReportServiceConfiguration
            {
                HostAppId = "POS.Reports",
                Storage = new FileStorage(),
                ReportResolver = new MyResolver()
            };


        }

        protected override HttpStatusCode SendMailMessage(MailMessage mailMessage)
        {
            throw new System.NotImplementedException("This method should be implemented in order to send mail messages");

            //using (var smtpClient = new SmtpClient("smtp01.mycompany.com", 25))
            //{
            //    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    smtpClient.EnableSsl = false;

            //    smtpClient.Send(mailMessage);
            //}
            //return HttpStatusCode.OK;
        }
    }

}

