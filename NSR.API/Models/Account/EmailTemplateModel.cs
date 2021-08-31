using System.ComponentModel.DataAnnotations;

namespace NSR.Account
{
    public class EmailTemplateModel
    {
        public int EmailTemplateID { get; set; }
        public string EmailTemplateName { get; set; }
        public string EmailSubjectLineEnglish { get; set; }
        public string EmailSubjectLineArabic { get; set; }
        public string EmailTemplateHTMLEnglish { get; set; }
        public string EmailTemplateHTMLArabic { get; set; }
        public int SMTPConfigurationID { get; set; }
    }
}