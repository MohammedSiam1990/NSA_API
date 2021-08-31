using NSR.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSR.API.Models
{
  public class CityModel
  {

        public int CityId { get; set; }
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
