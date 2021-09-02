using NSR.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSR.API.Models
{
    public class SchoolModel
    {


        public int SchoolId { get; set; }

        public string SchoolName1 { get; set; }

        public string SchoolName2 { get; set; }

        public string SchoolName3 { get; set; }

        public string SchoolName4 { get; set; }

        public string SchoolNameEN { get; set; }

        public string SchoolQID { get; set; }

        public string SchoolCertificateDegree { get; set; }
        public int? SchoolCertificateDegreeDate { get; set; }

        public string SchoolMobile1 { get; set; }

        public string SchoolMobile2 { get; set; }

        public string SchoolPhoneHome { get; set; }

        public string SchoolFax { get; set; }

        public string SchoolMobileFriend { get; set; }

        public DateTime? SchoolBrithDayDate { get; set; }
        public int? SchoolSocialStatus { get; set; }
        public int? SchoolBloodType { get; set; }

        public string SchoolEmployer { get; set; }

        public string SchoolTypeWork { get; set; }

        public string SchoolPhoneWork { get; set; }

        public string SchoolFaxWork { get; set; }

        public string SchoolAddressWork { get; set; }
        public int? SchoolZone { get; set; }
        [StringLength(100)]
        public string SchoolStreetName { get; set; }
        public int? SoliderHomeNo { get; set; }
        public long? InsertedBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? LastModifyDate { get; set; }
        public long? ModifiedBy { get; set; }
        public long? ApprovedBy { get; set; }

        public DateTime? ApprovedDate { get; set; }
        public int? StatusID { get; set; }

        public string ImageName_Passport { get; set; }

        public string ImageName_workletter_MinistryDevelopment { get; set; }

        public string ImageName_Certificates { get; set; }

        public string ImageName_person { get; set; }

        public string ImageName_QID { get; set; }

        public string ImageName_Health { get; set; }

        public string ImageName_married { get; set; }

        public string ImageName_other { get; set; }
        public int? School_Delay_Exemption_Exception { get; set; }


        public int? IsEmployee { get; set; }
        public bool? IsAddDelay_Exemption_Exception { get; set; }
        public int? ManagementAction { get; set; }
        public string Management_Notes { get; set; }


        public string ImageName_Transcript { get; set; }
        public bool? IsMedicalTest { get; set; }

        public int? Ministry { get; set; }

        public string Notes_Other { get; set; }
    }
}
