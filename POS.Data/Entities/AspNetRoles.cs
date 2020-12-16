﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Entities
{
    
    public partial class AspNetRoles : IdentityRole
    {
        public string NameAr { get; set; }
        public int CompanyId { get; set; }
    }
}
