﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Entities
{
    public class Address
    {
        [Key]
        public long AddressID { get; set; }
        public string Title { get; set; }
        public string AddressDescription { get; set; }
        public string PhoneMobile { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string GPSAddress { get; set; }
        public int? CountryID { get; set; }
        public int? CityID { get; set; }
        public int? DistrictID { get; set; }
        public string Area { get; set; }
        public string Street { get; set; }
        public string BuildingInf { get; set; }
        public long CustomerID { get; set; }
        public bool? InActive { get; set; }

    }
}
