﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Models
{
    public partial class AddressModel
    {
        public long AddressID { get; set; }
        public string Title { get; set; }
        public string AddressDescription { get; set; }
        public string PhoneMobile { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string GPSAddress { get; set; }
        public int? CountryID { get; set; }
        public int? CityID { get; set; }
        public int? DistrictID { get; set; }
        public string Area { get; set; }
        public string Street { get; set; }
        public string BuildingInf { get; set; }
        public int? CustomerID { get; set; }
        public int? StatusID { get; set; }

    }
}
