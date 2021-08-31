using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

 

namespace NSR.Entities 
{
    [Table("Soldier")]
    public partial class Soldier
    {
        [Key]
        public int SoldierId { get; set; }
        [StringLength(100)]
        public string SoldierName1 { get; set; }
        [StringLength(100)]
        public string SoldierName2 { get; set; }
        [StringLength(100)]
        public string SoldierName3 { get; set; }
        [StringLength(100)]
        public string SoldierName4 { get; set; }
        [StringLength(100)]
        public string SoldierNameEN { get; set; }
        [StringLength(100)]
        public string SoldierQID { get; set; }
        [StringLength(100)]
        public string SoldierCertificateDegree { get; set; }
        public int? SoldierCertificateDegreeDate { get; set; }
        [StringLength(50)]
        public string SoldierMobile1 { get; set; }
        [StringLength(50)]
        public string SoldierMobile2 { get; set; }
        [StringLength(50)]
        public string SoldierPhoneHome { get; set; }
        [StringLength(50)]
        public string SoldierFax { get; set; }
        [StringLength(50)]
        public string SoldierMobileFriend { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SoldierBrithDayDate { get; set; }
        public int? SoldierSocialStatus { get; set; }
        public int? SoldierBloodType { get; set; }
        [StringLength(100)]
        public string SoldierEmployer { get; set; }
        [StringLength(100)]
        public string SoldierTypeWork { get; set; }
        [StringLength(50)]
        public string SoldierPhoneWork { get; set; }
        [StringLength(50)]
        public string SoldierFaxWork { get; set; }
        [StringLength(200)]
        public string SoldierAddressWork { get; set; }
        public int? SoldierZone { get; set; }
        [StringLength(100)]
        public string SoldierStreetName { get; set; }
        public int? SoliderHomeNo { get; set; }
        public long? InsertedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifyDate { get; set; }
        public long? ModifiedBy { get; set; }
        [StringLength(100)]
        public string ImageName_Passport { get; set; }


        [StringLength(100)]
        public string ImageName_Clearance { get; set; }



        [StringLength(100)]
        public string ImageName_Certificates { get; set; }



        [StringLength(100)]
        public string ImageName_person { get; set; }



        [StringLength(100)]
        public string ImageName_militarycard { get; set; }




        [StringLength(100)]
        public string ImageName_other { get; set; }


        public int? Soldier_Delay_Exemption_Exception { get; set; }


        public long? ApprovedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApprovedDate { get; set; }
        public int? StatusID { get; set; }


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
