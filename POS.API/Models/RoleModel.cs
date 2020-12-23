using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Models
{
    public partial class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public int? CompanyId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public long? InsertedBy { get; set; }
        public long? ModifiedBy { get; set; }
        public List<RolesBrandsModel> RolesBrands { get; set; }
    }
}
