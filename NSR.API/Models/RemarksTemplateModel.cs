using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSR.API.Models
{
    public class RemarksTemplateModel
    {
        public int RemarksTemplateId { get; set; }
        public string RemarksTemplateName { get; set; }
        public string RemarksTemplateNameAr { get; set; }
        public int? StatusId { get; set; }
        public int BrandId { get; set; }
        public long? InsertedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int NumberOfMandatory { get; set; }
        public int UpperLimitForAdditions { get; set; }
        public virtual List<RemarksTemplateDetailsModel> RemarksTemplateDetails{ get; set; }
    }
}
