    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

namespace POS.DTO
{
    public partial class BrandsDto
    {
        public int BrandId { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
        public string BrandNameAr { get; set; }
        public string ImagePath { get; set; }
        public string PdfPath { get; set; }
        public string BrandNameF { get; set; }
        public string BrandNameArF { get; set; }
        public string ImagePathF { get; set; }
        public string PdfPathF { get; set; }

    }
}
