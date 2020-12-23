using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Entities
{
    public class RolesBrands
    {
        [Key]
        public long Id { get; set; }
        public int RoleID { get; set; }
        public int BrandID { get; set; }

    }
}
