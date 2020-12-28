using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Models
{
    public partial class LoginAuditModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime TransactionTime { get; set; }
        public int TransactionType { get; set; }
        public int? CompanyId { get; set; }

    }
}
