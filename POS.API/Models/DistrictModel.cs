using POS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Models
{
    public class DistrictModel
    {
        [Key]
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string DistrictNameAr { get; set; }
        public int CityId { get; set; }
        public bool? InActive { get; set; }
        public string CityName { get; set; }
        public string CityNameAr { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryNameAr { get; set; }
        public long? InsertedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public long? ModifiedBy { get; set; }
    }
}
