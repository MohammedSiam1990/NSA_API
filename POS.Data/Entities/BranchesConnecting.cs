using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Entities
{
    public class BranchesConnecting
    { 
        [Key]
        public long BranchConnectingID { get; set; }
        public int BranchID { get; set; }
        public int ConnectingID { get; set; }
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public long? InsertedBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
