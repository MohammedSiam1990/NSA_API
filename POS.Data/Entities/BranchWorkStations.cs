﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Entities
{
   public class BranchWorkStations
    {
        [Key]
        public int BranchWorkstationID { get; set; }
        public int BranchID { get; set; }
        public int CompanyID { get; set; }
        public string WorkstationName { get; set; }
        public string Serial { get; set; }
        public string Mac { get; set; }
        public int StatusID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? LastModifyDate { get; set; }

    }
}