using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

 

namespace NSR.Entities 
{
    [Table("University")]
    public partial class University
    {
        [Key]/// 3333333333333
        public int UniversityId { get; set; }
        [StringLength(100)]
        public string UniversityName1 { get; set; }
        [StringLength(100)]
        public string UniversityName2 { get; set; }
        [StringLength(100)]
        public string UniversityName3 { get; set; }
        [StringLength(100)]
        public string UniversityName4 { get; set; }
        [StringLength(100)]
        public string UniversityNameEN { get; set; }
        [StringLength(100)]
        public string UniversityQID { get; set; }
        [StringLength(100)]
        public string UniversityCertificateDegree { get; set; }
        public int? UniversityCertificateDegreeDate { get; set; }
        [StringLength(50)]
        public string UniversityMobile1 { get; set; }
        [StringLength(50)]
        public string UniversityMobile2 { get; set; }
        [StringLength(50)]
        public string UniversityPhoneHome { get; set; }
        [StringLength(50)]
        public string UniversityFax { get; set; }
        [StringLength(50)]
        public string UniversityMobileFriend { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UniversityBrithDayDate { get; set; }
        public int? UniversitySocialStatus { get; set; }
        public int? UniversityBloodType { get; set; }
        [StringLength(100)]
        public string UniversityEmployer { get; set; }
        [StringLength(100)]
        public string UniversityTypeWork { get; set; }
        [StringLength(50)]
        public string UniversityPhoneWork { get; set; }
        [StringLength(50)]
        public string UniversityFaxWork { get; set; }
        [StringLength(200)]
        public string UniversityAddressWork { get; set; }
        public int? UniversityZone { get; set; }
        [StringLength(100)]
        public string UniversityStreetName { get; set; }
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
        public int? University_Delay_Exemption_Exception { get; set; }
        [StringLength(100)]
        public string UniversitySpecialization { get; set; }
        [StringLength(100)]
        public string UniversityLocation { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? UniversityAverage { get; set; }

        public int? IsEmployee { get; set; }
        public bool? IsAddDelay_Exemption_Exception { get; set; }
        public int? ManagementAction { get; set; }
        public string Management_Notes { get; set; }


        [StringLength(100)]
        public string ImageName_Transcript { get; set; } 

        public int? Ministry { get; set; }

        public string Notes_Other { get; set; }
        
    }
}
