using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Models
{
    public partial class RolesBrandsModel
    {
        public long Id { get; set; }
        public int RoleID { get; set; }
        public int BrandID { get; set; }
    }
}
