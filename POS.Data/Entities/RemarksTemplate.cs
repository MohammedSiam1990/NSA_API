using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Entities
{
    public partial class RemarksTemplate
    {
        [Key]
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
        public int NumberOfMandatory { get; set; }
        public int UpperLimitForAdditions { get; set; }

        public virtual ICollection<RemarksTemplateDetails> RemarksTemplateDetails { get; set; }
    }
}
