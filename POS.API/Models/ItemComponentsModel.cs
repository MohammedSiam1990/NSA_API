using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Models
{
    public class ItemComponentsModel
    {
        public long ItemComponentID { get; set; }
        public int TypeID { get; set; }
        public long MainItemID { get; set; }
        public long MainItemUOMID { get; set; }
        public long CompItemID { get; set; }
        public long CompItemUOMID { get; set; }
        public decimal? Qty { get; set; }
        public bool IsMain { get; set; }
        public bool IsBase { get; set; }
        public string InsertedBy { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
