using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.Dto.Account
{
    public class UserRole : IdentityRole<string>
    {
        public string NameAr { get; set; }
        public int CompanyId { get; set; }
    }
}
