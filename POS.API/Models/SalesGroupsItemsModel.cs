using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Models
{
    public partial class SalesGroupsItemsModel
    {

        public long SalesGroupItemsID { get; set; }
        public int SalesGroupID { get; set; }
        public long ItemID { get; set; }
        public int OrderID { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
