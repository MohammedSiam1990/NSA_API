using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.Entities
{
    public class LoginAudit
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionType { get; set; }
        public int? CompanyId { get; set; }

    }
}
