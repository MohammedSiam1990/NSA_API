using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Entities
{
    public class SalesGroupsItems
    {
        [Key]
        public long SalesGroupItemsID { get; set; }
        public int SalesGroupID { get; set; }
        public long ItemID { get; set; }
        public int OrderID { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? CreateDate { get; set; }

    }
}
