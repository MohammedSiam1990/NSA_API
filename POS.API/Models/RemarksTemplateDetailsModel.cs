using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Models
{
    public class RemarksTemplateDetailsModel
    {
        public int RemarksTemplateDetailsD { get; set; }
        public string RemarkName1 { get; set; }
        public string RemarkName2 { get; set; }
        public int TypeId { get; set; }
        public int? ItemId { get; set; }
        public decimal? Price { get; set; }
        public decimal? Calories { get; set; }
        public decimal? Quantitiy { get; set; }
        
    }
}
