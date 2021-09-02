using NSR.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSR.API.Models
{
  public class SoldierModel
    {
        
        public int SoldierId { get; set; }
        
        public string SoldierName1 { get; set; }
       
        public string SoldierName2 { get; set; }
       
        public string SoldierName3 { get; set; }
       
        public string SoldierName4 { get; set; }
       
        public string SoldierNameEN { get; set; }
       
        public string SoldierQID { get; set; }
       
        public string SoldierCertificateDegree { get; set; }
        public int? SoldierCertificateDegreeDate { get; set; }
        
        public string SoldierMobile1 { get; set; }
        
        public string SoldierMobile2 { get; set; }
        
        public string SoldierPhoneHome { get; set; }
        
        public string SoldierFax { get; set; }
        
        public string SoldierMobileFriend { get; set; }
        
        public DateTime? SoldierBrithDayDate { get; set; }
        public int? SoldierSocialStatus { get; set; }
        public int? SoldierBloodType { get; set; }
       
        public string SoldierEmployer { get; set; }
       
        public string SoldierTypeWork { get; set; }
        
        public string SoldierPhoneWork { get; set; }
        
        public string SoldierFaxWork { get; set; }
         
        public string SoldierAddressWork { get; set; }
        public int? SoldierZone { get; set; }
       
        public string SoldierStreetName { get; set; }
        public int? SoliderHomeNo { get; set; }
        public long? InsertedBy { get; set; }
         
        public DateTime? CreateDate { get; set; }
         
        public DateTime? LastModifyDate { get; set; }
        public long? ModifiedBy { get; set; }
       
        public string ImageName_Passport { get; set; }

        public string ImageName_Clearance { get; set; }
        public string ImageName_Certificates { get; set; }
        public string ImageName_person { get; set; }
        public string ImageName_militarycard { get; set; }


         
        public string ImageName_other { get; set; }


        public int? Soldier_Delay_Exemption_Exception { get; set; }
        public long? ApprovedBy { get; set; }
         
        public DateTime? ApprovedDate { get; set; }
        public int? StatusID { get; set; }

        public int? IsEmployee { get; set; }
        public bool? IsAddDelay_Exemption_Exception { get; set; }
        public int? ManagementAction { get; set; }
        public string Management_Notes { get; set; }


        public string ImageName_Transcript { get; set; } 

        public int? Ministry { get; set; }

        public string Notes_Other { get; set; }
    }
}
