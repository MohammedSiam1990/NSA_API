using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Models
{
    public class RemarksTemplateModel
    {
        public int RemarksTemplateId { get; set; }
        public string RemarksTemplateName { get; set; }
        public string RemarksTemplateNameAr { get; set; }
        public int? StatusId { get; set; }
        public int BrandId { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public virtual List<RemarksTemplateDetailsModel> RemarksTemplateDetails{ get; set; }
    }
}
