using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace NSR.Entities
{
    [Table("School")]
    public partial class School
    {
        [Key]
        public int SchoolId { get; set; }
        [StringLength(100)]
        public string SchoolName1 { get; set; }
        [StringLength(100)]
        public string SchoolName2 { get; set; }
        [StringLength(100)]
        public string SchoolName3 { get; set; }
        [StringLength(100)]
        public string SchoolName4 { get; set; }
        [StringLength(100)]
        public string SchoolNameEN { get; set; }
        [StringLength(100)]
        public string SchoolQID { get; set; }
        [StringLength(100)]
        public string SchoolCertificateDegree { get; set; }
        public int? SchoolCertificateDegreeDate { get; set; }
        [StringLength(50)]
        public string SchoolMobile1 { get; set; }
        [StringLength(50)]
        public string SchoolMobile2 { get; set; }
        [StringLength(50)]
        public string SchoolPhoneHome { get; set; }
        [StringLength(50)]
        public string SchoolFax { get; set; }
        [StringLength(50)]
        public string SchoolMobileFriend { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SchoolBrithDayDate { get; set; }
        public int? SchoolSocialStatus { get; set; }
        public int? SchoolBloodType { get; set; }
        [StringLength(100)]
        public string SchoolEmployer { get; set; }
        [StringLength(100)]
        public string SchoolTypeWork { get; set; }
        [StringLength(50)]
        public string SchoolPhoneWork { get; set; }
        [StringLength(50)]
        public string SchoolFaxWork { get; set; }
        [StringLength(200)]
        public string SchoolAddressWork { get; set; }
        public int? SchoolZone { get; set; }
        [StringLength(100)]
        public string SchoolStreetName { get; set; }
        public int? SoliderHomeNo { get; set; }
        public long? InsertedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifyDate { get; set; }
        public long? ModifiedBy { get; set; }
        public long? ApprovedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApprovedDate { get; set; }
        public int? StatusID { get; set; }
        [StringLength(100)]
        public string ImageName_Passport { get; set; }
        [StringLength(100)]
        public string ImageName_workletter_MinistryDevelopment { get; set; }
        [StringLength(100)]
        public string ImageName_Certificates { get; set; }
        [StringLength(100)]
        public string ImageName_person { get; set; }
        [StringLength(100)]
        public string ImageName_QID { get; set; }
        [StringLength(100)]
        public string ImageName_Health { get; set; }
        [StringLength(100)]
        public string ImageName_married { get; set; }
        [StringLength(100)]
        public string ImageName_other { get; set; }
        public int? School_Delay_Exemption_Exception { get; set; }
  

        public int? IsEmployee { get; set; }
        public bool? IsAddDelay_Exemption_Exception { get; set; }
        public int? ManagementAction { get; set; }
        public string Management_Notes { get; set; }


        [StringLength(100)]
        public string ImageName_Transcript { get; set; }
        public bool? IsMedicalTest { get; set; }

        public int? Ministry { get; set; }

        public string Notes_Other { get; set; }

    }
}
