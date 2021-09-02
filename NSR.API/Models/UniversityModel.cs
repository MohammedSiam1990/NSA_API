using NSR.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSR.API.Models
{
  public class UniversityModel
    {

      
        public int UniversityId { get; set; }
       
        public string UniversityName1 { get; set; }
        
        public string UniversityName2 { get; set; }
       
        public string UniversityName3 { get; set; }
      
        public string UniversityName4 { get; set; }
       
        public string UniversityNameEN { get; set; }
       
        public string UniversityQID { get; set; }
       
        public string UniversityCertificateDegree { get; set; }
        public int? UniversityCertificateDegreeDate { get; set; }
        
        public string UniversityMobile1 { get; set; }
    
        public string UniversityMobile2 { get; set; }
     
        public string UniversityPhoneHome { get; set; }
  
        public string UniversityFax { get; set; }
   
        public string UniversityMobileFriend { get; set; }
     
        public DateTime? UniversityBrithDayDate { get; set; }
        public int? UniversitySocialStatus { get; set; }
        public int? UniversityBloodType { get; set; }
     
        public string UniversityEmployer { get; set; }
     
        public string UniversityTypeWork { get; set; }
       
        public string UniversityPhoneWork { get; set; }
      
        public string UniversityFaxWork { get; set; }
       
        public string UniversityAddressWork { get; set; }
        public int? UniversityZone { get; set; }
        [StringLength(100)]
        public string UniversityStreetName { get; set; }
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
        public int? University_Delay_Exemption_Exception { get; set; }
   
        public string UniversitySpecialization { get; set; }
   
        public string UniversityLocation { get; set; }
      
        public decimal? UniversityAverage { get; set; }

        public int? IsEmployee { get; set; }
        public bool? IsAddDelay_Exemption_Exception { get; set; }
        public int? ManagementAction { get; set; }
        public string Management_Notes { get; set; }

        public string ImageName_Transcript { get; set; }
    

        public int? Ministry { get; set; }


        public string Notes_Other { get; set; }





    }
}
